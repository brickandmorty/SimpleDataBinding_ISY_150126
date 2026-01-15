using System.ComponentModel;

namespace SimpleDataBindingApp.Tests;

/// <summary>
/// Unit tests for DataViewModel business logic and INotifyPropertyChanged implementation
/// </summary>
public class DataViewModelTests
{
    [Fact]
    public void PostRating_WhenSetTo10_ShouldShowSmiley()
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.PostRating = 10;

        // Assert
        Assert.True(viewModel.ShowSmiley);
        Assert.Equal("😊 Perfekte Bewertung!", viewModel.SmileyText);
    }

    [Fact]
    public void PostRating_WhenSetToNot10_ShouldNotShowSmiley()
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.PostRating = 9;

        // Assert
        Assert.False(viewModel.ShowSmiley);
        Assert.Equal("", viewModel.SmileyText);
    }

    [Fact]
    public void BankDeduction_WhenGreaterOrEqual1000_ShouldShowWarning()
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.BankDeduction = 1000m;

        // Assert
        Assert.True(viewModel.ShowWarning);
        Assert.Equal("⚠️ WARNUNG: Hohe Abbuchung!", viewModel.WarningText);
    }

    [Fact]
    public void BankDeduction_WhenLessThan1000_ShouldNotShowWarning()
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.BankDeduction = 999.99m;

        // Assert
        Assert.False(viewModel.ShowWarning);
        Assert.Equal("", viewModel.WarningText);
    }

    [Fact]
    public void BankDeduction_WhenGreaterThan1000_ShouldShowWarning()
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.BankDeduction = 5000m;

        // Assert
        Assert.True(viewModel.ShowWarning);
        Assert.Equal("⚠️ WARNUNG: Hohe Abbuchung!", viewModel.WarningText);
    }

    [Fact]
    public void UserName_WhenChanged_ShouldRaisePropertyChanged()
    {
        // Arrange
        var viewModel = new DataViewModel();
        var propertyChangedRaised = false;
        viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(viewModel.UserName))
                propertyChangedRaised = true;
        };

        // Act
        viewModel.UserName = "TestUser";

        // Assert
        Assert.True(propertyChangedRaised);
        Assert.Equal("TestUser", viewModel.UserName);
    }

    [Fact]
    public void PostRating_WhenChanged_ShouldRaiseMultiplePropertyChangedEvents()
    {
        // Arrange
        var viewModel = new DataViewModel();
        var raisedProperties = new List<string>();
        viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName != null)
                raisedProperties.Add(args.PropertyName);
        };

        // Act
        viewModel.PostRating = 10;

        // Assert
        Assert.Contains(nameof(viewModel.PostRating), raisedProperties);
        Assert.Contains(nameof(viewModel.ShowSmiley), raisedProperties);
        Assert.Contains(nameof(viewModel.SmileyText), raisedProperties);
    }

    [Fact]
    public void BankDeduction_WhenChanged_ShouldRaiseMultiplePropertyChangedEvents()
    {
        // Arrange
        var viewModel = new DataViewModel();
        var raisedProperties = new List<string>();
        viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName != null)
                raisedProperties.Add(args.PropertyName);
        };

        // Act
        viewModel.BankDeduction = 1500m;

        // Assert
        Assert.Contains(nameof(viewModel.BankDeduction), raisedProperties);
        Assert.Contains(nameof(viewModel.ShowWarning), raisedProperties);
        Assert.Contains(nameof(viewModel.WarningText), raisedProperties);
    }

    [Fact]
    public void IsActive_WhenChanged_ShouldRaisePropertyChanged()
    {
        // Arrange
        var viewModel = new DataViewModel();
        var propertyChangedRaised = false;
        viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(viewModel.IsActive))
                propertyChangedRaised = true;
        };

        // Act
        viewModel.IsActive = true;

        // Assert
        Assert.True(propertyChangedRaised);
        Assert.True(viewModel.IsActive);
    }

    [Fact]
    public void ProgressValue_WhenChanged_ShouldRaisePropertyChanged()
    {
        // Arrange
        var viewModel = new DataViewModel();
        var propertyChangedRaised = false;
        viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(viewModel.ProgressValue))
                propertyChangedRaised = true;
        };

        // Act
        viewModel.ProgressValue = 75.0;

        // Assert
        Assert.True(propertyChangedRaised);
        Assert.Equal(75.0, viewModel.ProgressValue);
    }

    [Fact]
    public void DisplayMessage_WhenChanged_ShouldRaisePropertyChanged()
    {
        // Arrange
        var viewModel = new DataViewModel();
        var propertyChangedRaised = false;
        viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(viewModel.DisplayMessage))
                propertyChangedRaised = true;
        };

        // Act
        viewModel.DisplayMessage = "Test Message";

        // Assert
        Assert.True(propertyChangedRaised);
        Assert.Equal("Test Message", viewModel.DisplayMessage);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(9)]
    [InlineData(11)]
    public void PostRating_WhenNotEqualTo10_ShouldNotShowSmiley(int rating)
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.PostRating = rating;

        // Assert
        Assert.False(viewModel.ShowSmiley);
        Assert.Empty(viewModel.SmileyText);
    }

    [Theory]
    [InlineData(1000)]
    [InlineData(1500)]
    [InlineData(10000)]
    public void BankDeduction_WhenGreaterOrEqualTo1000_ShouldShowWarning(decimal amount)
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.BankDeduction = amount;

        // Assert
        Assert.True(viewModel.ShowWarning);
        Assert.NotEmpty(viewModel.WarningText);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    [InlineData(999)]
    [InlineData(999.99)]
    public void BankDeduction_WhenLessThan1000_ShouldNotShowWarning_Theory(decimal amount)
    {
        // Arrange
        var viewModel = new DataViewModel();

        // Act
        viewModel.BankDeduction = amount;

        // Assert
        Assert.False(viewModel.ShowWarning);
        Assert.Empty(viewModel.WarningText);
    }
}
