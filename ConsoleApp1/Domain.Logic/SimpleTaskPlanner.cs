using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic
{
    public class SimpleTaskPlanner
    {
        // Тут будуть методи

        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            var itemsAsList = items.ToList();
            itemsAsList.Sort(CompareWorkItems);
            return itemsAsList.ToArray();
        }

        private static int CompareWorkItems(WorkItem firstItem, WorkItem secondItem)
        {
            // Спочатку сортування за Priority (за спаданням)
            int priorityComparison = secondItem.Priority.CompareTo(firstItem.Priority);
            if (priorityComparison != 0)
                return priorityComparison;

            // Потім за DueDate (за зростанням)
            int dateComparison = firstItem.DueDate.CompareTo(secondItem.DueDate);
            if (dateComparison != 0)
                return dateComparison;

            // Потім за Title (алфавіт)
            return string.Compare(firstItem.Title, secondItem.Title, StringComparison.OrdinalIgnoreCase);
        }

    }
}
