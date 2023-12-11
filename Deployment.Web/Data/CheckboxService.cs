using System;
using System.Collections.Generic;

namespace Deployment.Web.Data;
public class CheckboxService
{
    public List<CheckboxItem> CheckboxItems { get; set; }
    public CheckboxItem SelectedCheckboxItem { get; private set; }

    public event Action<string> OnCheckboxUpdate;
    public event Action OnSelectedCheckboxItemChange;

    public CheckboxService()
    {
        CheckboxItems = new List<CheckboxItem>
        {
            new CheckboxItem { IsChecked = false, Label = "Checkbox 1" },
            new CheckboxItem { IsChecked = false, Label = "Checkbox 2" },
            // Add more checkbox items as needed
        };
    }

    public void UpdateLabels(string text)
    {
        // Simulating backend data update
        foreach (var item in CheckboxItems)
        {
            // Update the label based on some logic or data from the backend
            item.Description = "Updated " + text;
        }

        NotifyCheckboxUpdate(text);
    }

    private void NotifyCheckboxUpdate(string text)
    {
        OnCheckboxUpdate?.Invoke(text);
    }

    public void SetSelectedCheckboxItem(CheckboxItem item)
    {
        SelectedCheckboxItem = item;
        NotifySelectedCheckboxItemChange();
    }

    private void NotifySelectedCheckboxItemChange()
    {
        OnSelectedCheckboxItemChange?.Invoke();
    }
}

public class CheckboxItem
{
    public bool IsChecked { get; set; }
    public string Label { get; set; }

    public IList<string> Parameters{get;} = new List<string>();
    public string Description { get; set; }
}
