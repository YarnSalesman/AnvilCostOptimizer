using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Minecraft;

namespace Optimizer
{
    class OptimizerC
    {
        private class OptimizerS
        {
            public List<Item> ItemList;
            public List<AnvilStep> StepList;
            public int TotalCost;
            
            public OptimizerS(List<Item> itemList)
            {
                ItemList = itemList;
                StepList = new List<AnvilStep>();
                TotalCost = 0;
            }
        }

        private CancellationToken CToken;
        private List<AnvilStep> ResultStepList;
        private int ResultTotalCost;
        
        public OptimizerC(CancellationToken cToken)
        {
            CToken = cToken;
        }

        private AnvilStep Anvil(Item target, Item sacrifice)
        {
            //quick check that target and sacrifice items are compatible
            if (target.Info.Id != sacrifice.Info.Id && sacrifice.Info.Id != MC.BOOK)
            {
                return null;
            }
            
            //compare both items SacrificeValue. Don't bother combining if sacrifice costs more
            if (target.SacrificeValue < sacrifice.SacrificeValue && target.Info.Id == sacrifice.Info.Id)
            {
                return null;
            }
            
            //check if sacrifice has any applicable enchantments
            if (0 == (target.Info.ApplicableEnchantments & sacrifice.AppliedEnchantments))
            {
                return null;
            }
            
            int stepCost = 0;
            
            //create result item from target Item
            Item result = MC.CopyItem(target);
            
            //add any prior work penalties
            stepCost += ((1 << target.AnvilUses) - 1);
            stepCost += ((1 << sacrifice.AnvilUses) - 1);
            
            //update resulting anvil uses
            result.AnvilUses = target.AnvilUses >= sacrifice.AnvilUses
                               ? 
                               target.AnvilUses + 1 
                               : 
                               sacrifice.AnvilUses + 1;
            
            //add enchantment costs on result item
            foreach (Enchantment s in sacrifice.AppliedEnchantmentsList)
            {
                //ignore any enchantment that cannot be applied to the target and move on
                if (!MC.IsEnchantmentApplicable(result.Info.Id, s.Id))
                {
                    continue;
                }
            
                //add 1 level if enchantment is incompatible with one on target and move on
                if (0 != (result.AppliedEnchantments & MC.Enchantments[s.Id].IncompatibleEnchantments))
                {
                    //if the enchantment is to be preserved then no point in combining.
                    if (s.Preserved == true || sacrifice.AppliedEnchantmentsList.Count == 1)
                    {
                        return null;
                    }
            
                    stepCost += 1;
            
                    continue;
                }
            
                //see if enchantment is already on target
                Enchantment t = result.AppliedEnchantmentsList.Find(x => x.Id == s.Id);
            
                //if not, determine the final level as a result of combining these enchantments
                if (t != null)
                {
                    int level;
                
                    if (s.Level == t.Level)
                    {
                        level = MC.NextLevel(s);
                    }
                    else if (s.Level > t.Level)
                    {
                        level = s.Level;
                    }
                    else
                    {
                        //calculate step cost but don't update the result item and move on
                        level = t.Level;
                        stepCost += MC.EnchantmentValue(sacrifice.Info.Id, s.Id, level);
                        continue;
                    }
                
                    stepCost += MC.EnchantmentValue(sacrifice.Info.Id, s.Id, level);
                
                    //update the enchantments level and result items sacrifice value
                    result.SacrificeValue -= MC.EnchantmentValue(result.Info.Id, t.Id, t.Level);
                    t.Level = level;
                    result.SacrificeValue += MC.EnchantmentValue(result.Info.Id, t.Id, t.Level);
                }
                else
                {
                    //add the new enchantment otherwise
                    stepCost += MC.EnchantmentValue(sacrifice.Info.Id, s.Id, s.Level);
                    result.AddEnchantment(s.Id, s.Level, s.Preserved, true);
                }
            }
            
            //abort if survival cost limit is reached
            if (stepCost > 39)
            {
                return null;
            }
            
            return new AnvilStep
            {
                Target = target,
                Sacrifice = sacrifice,
                Result = result,
                Cost = stepCost
            };
        }

        //This algorithm produces many duplicate sequences and will be noticeably
        //slow to compute the best sequence when combining 7+ items.
        //Its fast enough regardless even at 7 items but it could be faster. 
        private void Combine(OptimizerS o)
        {
            for (int i = 0; i < o.ItemList.Count; i++)
            {
                Item target = o.ItemList[i];
                o.ItemList.RemoveAt(i);
    
                for (int j = 0; j < o.ItemList.Count; j++)
                {
                    Item sacrifice = o.ItemList[j];
    
                    AnvilStep s = Anvil(target, sacrifice);
    
                    if (s != null)
                    {
                        o.TotalCost += s.Cost;
                    
                        if (o.TotalCost <= ResultTotalCost)
                        {
                            o.StepList.Add(s);
                            o.ItemList.RemoveAt(j);
                            o.ItemList.Insert(0, s.Result);
                            Combine(o);
                            o.ItemList.Insert(j, sacrifice);
                            o.StepList.RemoveAt(o.StepList.Count - 1);
                        }
    
                        o.TotalCost -= s.Cost;
                    }
    
                    if (CToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
    
                //if there are no items to choose from then a seqence has been computed
                if (o.ItemList.Count == 0)
                {
                    //if the new cost and old cost are the same find out which sequence has
                    //the average lower step cost value.
                    if (o.TotalCost == ResultTotalCost)
                    {
                        int [] s1 = o.StepList.Select(x => x.Cost).ToArray();
                        int [] s2 = ResultStepList.Select(x => x.Cost).ToArray();
                    
                        Array.Sort(s1);
                        Array.Sort(s2);
                    
                        for (int c = s1.Length - 1; c >= 0; c--)
                        {
                            if (s1[c] > s2[c])
                            {
                                return;
                            }
                            if (s1[c] < s2[c])
                            {
                                break;
                            }
                        }
                    }
            
                    //copy the new sequence and cost to the results
                    ResultStepList = new List<AnvilStep>();
            
                    foreach (AnvilStep s in o.StepList)
                    {
                        ResultStepList.Add(MC.CopyAnvilStep(s));
                    }
            
                    ResultTotalCost = o.TotalCost;
            
                    return;
                }
    
                o.ItemList.Insert(i, target);
    
                if (CToken.IsCancellationRequested)
                {
                    break;
                }
            }
    
            o.ItemList.RemoveAt(0);
        }

        public Tuple<List<AnvilStep>,int> StartOptTask(List<Item> itemList)
        {
            OptimizerS o = new OptimizerS(itemList);
            ResultTotalCost = 0x7FFFFFFF;
            Combine(o);
            return new Tuple<List<AnvilStep>, int>(ResultStepList, ResultTotalCost);
        }
    }
}
