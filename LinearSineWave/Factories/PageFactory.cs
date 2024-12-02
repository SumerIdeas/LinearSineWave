using System;
using LinearSineWave.Data;
using LinearSineWave.ViewModels;

namespace LinearSineWave.Factories;

public class PageFactory(Func<ApplicationPages, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(ApplicationPages pageName) => factory.Invoke(pageName);
}