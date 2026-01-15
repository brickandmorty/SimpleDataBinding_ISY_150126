# Simple Data Binding Demo - WPF Application

Eine WPF-Anwendung zur Demonstration von Data Binding mit INotifyPropertyChanged und verschiedenen UpdateSourceTrigger-Modi.

## Projektstruktur

```
SimpleDataBindingApp/
├── App.xaml / App.xaml.cs          - Anwendungseinstiegspunkt
├── MainWindow.xaml                  - Hauptfenster mit Data Binding Beispielen
├── MainWindow.xaml.cs               - Code-Behind für MainWindow
├── DataViewModel.cs                 - ViewModel mit INotifyPropertyChanged
├── BoolToColorConverter.cs          - Value Converter für Farbkonvertierung
└── SimpleDataBindingApp.csproj      - Projektdatei
```

## Implementierte Anforderungen

### 1. Source-Objekt (DataViewModel.cs)

Das ViewModel implementiert `INotifyPropertyChanged` und enthält:

#### Properties mit unterschiedlichen Datentypen:
- **UserName** (string) - Benutzername
- **PostRating** (int) - Bewertung von 0-10
- **BankDeduction** (decimal) - Bankabbuchungsbetrag in Euro
- **IsActive** (bool) - Aktiv/Inaktiv Status
- **ProgressValue** (double) - Fortschrittswert 0-100
- **DisplayMessage** (string) - Anzeigenachricht

#### Fachlogiken bei Property-Änderungen:

1. **Post-Bewertung mit Smiley (PostRating)**
   - Wenn `PostRating == 10`, wird ein Smiley 😊 mit Text "Perfekte Bewertung!" angezeigt
   - Computed Properties: `ShowSmiley`, `SmileyText`

2. **Bankabbuchung mit Warnung (BankDeduction)**
   - Wenn `BankDeduction >= 1000 Euro`, wird eine Warnung ⚠️ "WARNUNG: Hohe Abbuchung!" angezeigt
   - Computed Properties: `ShowWarning`, `WarningText`

### 2. XAML View mit Data Binding (MainWindow.xaml)

#### Verwendete Controls:
- **TextBox** - Texteingabe für UserName, PostRating, BankDeduction, DisplayMessage
- **TextBlock** - Anzeige von Werten und Meldungen
- **CheckBox** - IsActive Status
- **Slider** - ProgressValue Auswahl
- **Button** - Explicit Update Trigger
- **Label** - DisplayMessage Anzeige

#### Verwendete DependencyProperties:
- **Text** (TextBox, TextBlock) - Textinhalt
- **Content** (Label, Button) - Inhalt
- **IsChecked** (CheckBox) - Auswahlstatus
- **Value** (Slider) - Schiebereglerwert

#### UpdateSourceTrigger Modi:

1. **PropertyChanged** - Sofortige Aktualisierung bei jeder Änderung
   - UserName TextBox
   - BankDeduction TextBox
   - IsActive CheckBox

2. **LostFocus** - Aktualisierung wenn Fokus verloren geht
   - PostRating TextBox
   - DisplayMessage TextBox (Default für TextBox)

3. **Explicit** - Manuelle Aktualisierung per Button
   - ProgressValue Slider mit "Update" Button

4. **Default** - Standard-Verhalten des Controls
   - DisplayMessage TextBox (entspricht LostFocus)

#### Value Converter:
- **BoolToColorConverter** - Konvertiert Boolean zu Brush (Grün für true, Rot für false)

## Anwendung ausführen

### Voraussetzungen:
- .NET 10.0 SDK oder höher
- Windows OS (oder EnableWindowsTargeting für Cross-Platform-Build)

### Build und Run:
```bash
cd SimpleDataBindingApp
dotnet restore
dotnet build
dotnet run
```

## Funktionsweise

1. **UserName**: Geben Sie einen Namen ein - der Wert wird sofort unterhalb angezeigt (PropertyChanged)

2. **Post-Bewertung**: Geben Sie eine Zahl ein und klicken Sie außerhalb des Feldes (LostFocus). Bei der Eingabe von "10" erscheint ein grüner Smiley mit "Perfekte Bewertung!"

3. **Bankabbuchung**: Geben Sie einen Betrag ein - ab 1000 Euro erscheint sofort eine rote Warnung (PropertyChanged)

4. **Status**: Aktivieren/Deaktivieren Sie die CheckBox - der Status wird farbig angezeigt (Grün=Aktiv, Rot=Inaktiv)

5. **Fortschritt**: Bewegen Sie den Slider und klicken Sie auf "Update" - erst dann wird der Wert aktualisiert (Explicit)

6. **Nachricht**: Geben Sie eine Nachricht ein - sie wird nach dem Verlassen des Feldes im Label angezeigt (Default/LostFocus)

## Technische Details

- **MVVM Pattern**: Trennung von View (XAML) und ViewModel (C#)
- **INotifyPropertyChanged**: Automatische UI-Aktualisierung bei Datenänderungen
- **Data Binding**: Deklarative Verknüpfung von UI und Daten
- **Computed Properties**: Berechnete Werte basierend auf anderen Properties
- **Value Converters**: Transformation von Daten für die Anzeige
