# SimpleDataBinding_ISY_150126
Aufgabe zum Thema Simples Databinding in WPF der LV ISY (FH Campus02)

## Projekt-Beschreibung

Diese Repository enthält eine vollständige WPF-Anwendung zur Demonstration von Simple Data Binding mit INotifyPropertyChanged.

## Implementierte Features

### ✅ Source-Objekt mit INotifyPropertyChanged
- Properties mit unterschiedlichen Datentypen (string, int, decimal, bool, double)
- Vollständige INotifyPropertyChanged Implementierung
- Automatische GUI-Aktualisierung bei Wertänderungen

### ✅ Fachlogiken
1. **Post-Bewertung**: Bei Bewertung von 10 wird ein Smiley 😊 angezeigt
2. **Bankabbuchung**: Bei Abbuchung >= 1000 Euro erscheint eine Warnung ⚠️

### ✅ XAML View mit Data Binding
- Verschiedene Controls: TextBox, Label, TextBlock, CheckBox, Slider, Button
- Verschiedene DependencyProperties: Text, Content, IsChecked, Value
- Unterschiedliche UpdateSourceTrigger: PropertyChanged, LostFocus, Explicit, Default

## Quick Start

```bash
cd SimpleDataBindingApp
dotnet restore
dotnet build
dotnet run
```

## Tests ausführen

```bash
cd SimpleDataBindingApp.Tests
dotnet test
```

## Dokumentation

- [SimpleDataBindingApp/README.md](SimpleDataBindingApp/README.md) - Ausführliche Dokumentation der Anwendung
- [IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md) - Implementierungs-Zusammenfassung

## Status

✅ Alle Anforderungen erfüllt  
✅ Build erfolgreich (0 Warnungen, 0 Fehler)  
✅ 22 Unit Tests bestanden  
✅ Keine Sicherheitsprobleme  
 
