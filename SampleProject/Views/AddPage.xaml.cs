using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}