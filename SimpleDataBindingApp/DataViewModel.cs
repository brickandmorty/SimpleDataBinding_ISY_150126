using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleDataBindingApp;

/// <summary>
/// ViewModel implementing INotifyPropertyChanged with different data types and business logic
/// </summary>
public class DataViewModel : INotifyPropertyChanged
{
    private string _userName = string.Empty;
    private int _postRating;
    private decimal _bankDeduction;
    private bool _isActive;
    private double _progressValue;
    private string _displayMessage = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// String property for user name
    /// </summary>
    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Integer property for post rating
    /// Business Logic: When rating is 10, display a smiley
    /// </summary>
    public int PostRating
    {
        get => _postRating;
        set
        {
            if (_postRating != value)
            {
                _postRating = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowSmiley));
                OnPropertyChanged(nameof(SmileyText));
            }
        }
    }

    /// <summary>
    /// Computed property: Show smiley when PostRating equals 10
    /// </summary>
    public bool ShowSmiley => _postRating == 10;

    /// <summary>
    /// Computed property: Smiley text to display
    /// </summary>
    public string SmileyText => ShowSmiley ? "😊 Perfekte Bewertung!" : "";

    /// <summary>
    /// Decimal property for bank deduction
    /// Business Logic: When deduction >= 1000, show warning
    /// </summary>
    public decimal BankDeduction
    {
        get => _bankDeduction;
        set
        {
            if (_bankDeduction != value)
            {
                _bankDeduction = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowWarning));
                OnPropertyChanged(nameof(WarningText));
            }
        }
    }

    /// <summary>
    /// Computed property: Show warning when BankDeduction >= 1000
    /// </summary>
    public bool ShowWarning => _bankDeduction >= 1000;

    /// <summary>
    /// Computed property: Warning text to display
    /// </summary>
    public string WarningText => ShowWarning ? "⚠️ WARNUNG: Hohe Abbuchung!" : "";

    /// <summary>
    /// Boolean property for active status
    /// </summary>
    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Double property for progress value (0-100)
    /// </summary>
    public double ProgressValue
    {
        get => _progressValue;
        set
        {
            if (Math.Abs(_progressValue - value) > 0.01)
            {
                _progressValue = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// String property for display message
    /// </summary>
    public string DisplayMessage
    {
        get => _displayMessage;
        set
        {
            if (_displayMessage != value)
            {
                _displayMessage = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Raises PropertyChanged event
    /// </summary>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
