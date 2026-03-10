using SampleProject.ViewModels;

namespace SampleProject.Views;

[QueryProperty(nameof(EntryId), "id")]
public partial class EditPage : ContentPage
{
    private EditViewModel _viewModel;
    public string EntryId { get; set; }

    public EditPage(EditViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is EditViewModel vm)
        {
            vm.LoadEntry(EntryId);
        }
    }
}