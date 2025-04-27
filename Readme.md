# MacroCalculator

## Cerinta:
- Implementarea unui proiect folosind principii solide de programare – 5 pct
- Tema proiectului este la alegere dar are urmatoarele requirements:
- Minim 2 design patterns (nu architectural patterns)
- Cele 2 design patterns trebuie specificate (in email sau intr-un readme)
- Proiectul trebuie sa contina minim doua unit teste
- Proiectul este adaugat pe un version control system
- Proiectul este compilabil si rulabil 
- Implementare in C#, Java, C++ sau Typescript
- Resurse si precizari
- Functionalitatea proiectul poate fi minimala, dar folosirea celor doua design patterns trebuie sa aiba sens si sa fie integrata in logica aplicatiei. Asocierea a doua design patterns fara legatura de business intr-o aplicatie ne-omogena nu va fi punctata.
- Exemplu de proiect necorespunzator: un factory care creaza tipuri de documente intr-o biblioteca asociat cu un strategy pattern folosit pentru sortarea unei liste de vanzari de masini
- Se pot lua teme la alegere; alte surse de inspiratie


# Design Patterns:
## Factory Pattern:
### Ce este Factory Pattern (sursa: Gpt):
- Factory Pattern este un pattern creational care permite crearea de obiecte fără a expune logica concretă de instanțiere clientului​.
- În loc să folosim direct operatorul new, apelăm o metodă specială (factory) care decide ce tip de obiect să creeze. Astfel, adăugarea unor noi tipuri de obiecte nu afectează codul client, iar întreaga logică de creare este concentrată într-un singur loc.

### Implementarea in cod:
Factory pattern este implementat de clasa  `DietPlanFactory`:
```c#
    public static class DietPlanFactory
    {
        public static IDietPlanPage CreateDietPlan(string dietType)
        {
            switch (dietType)
            {
                case "Bulk":
                    return new MacroCalculator.BulkPage.BulkPage();
                case "Cut":
                    return new MacroCalculator.CutPage.CutPage();
                case "Maintain":
                    return new MacroCalculator.Maintain.MaintainPage();
                default:
                    throw new ArgumentException("Invalid diet type");
            }
        }
    }
```
Metoda `CreateDietPlan` primeste tipul dietei alese de catre utilizator, unde va returna instanta respectiva:
   - Bulk
   - Cut
   - Mentinere


## Strategy Pattern
### Ce este Strategy Pattern (sursa: Gpt):
- Strategy Pattern este un pattern comportamental care permite definirea unei familii de algoritmi intercambiabili și alegerea unuia dintre ei la runtime​.
- Esența sa este că extrage variațiile unui algoritm în clase separate (strategie), astfel încât contextul (clasa client) să le poată utiliza pe toate prin aceeași interfață, comutând ușor între ele fără a modifica codul principal.

### Implementarea in cod:
- Strategy Pattern in aplicatie este folosit pentru calculul caloriilor in functie de obiectivul ales de catre utilizator (Bulk, Cut sau Mentinere).
- Clasele concrete `BulkCaloriesCalculator`, `CutCaloriesCalculator` și `MaintainCaloriesCalculator` implementeaza ICalorieCalculator, unde acestea aplica formula specifica pentru a calcula caloriile (kcal):
```c#
            // Sex
            string sex = sexComboBox.SelectedItem.ToString();

            // Activity factor
            string act = activityComboBox.SelectedItem.ToString();
            string actVal = act.Substring(act.IndexOf('(') + 1).TrimEnd(')');
            actVal = actVal.Replace(',', '.');
            double activityFactor = double.Parse(actVal, CultureInfo.InvariantCulture);

            // Caloric surplus
            int surplus = bulkComboBox.SelectedItem.ToString().Contains("250") ? 250 : 500;

            // Mifflin-St Jeor formula for BMR
            double bmr = 10 * weight + 6.25 * height - 5 * age + (sex == "Male" ? 5 : -161);

            // Calculating calories
            ICalorieCalculator calorieCalculator = new BulkCaloriesCalculator();
            double totalCalories = calorieCalculator.CalculateCalories(bmr, activityFactor, surplus);
```

# Preview:
https://github.com/user-attachments/assets/16aa3e18-cad4-4f54-8d73-b72ca401a2a3


# Documentatie:
### Links:
- https://reference.medscape.com/calculator/846/mifflin-st-jeor-equation
- https://www.k-state.edu/paccats/Contents/PA/PDF/Physical%20Activity%20and%20Controlling%20Weight.pdf#:~:text=Activity%20Multiplier%3A%20Sedentary%20%3D%20BMR,per%20day%2C%20or%20training%20for
- https://www.ncbi.nlm.nih.gov/books/NBK594226/#:~:text=Unlike%20protein%2C%20dietary%20recommendations%20for,27%5D%20%2043
- https://pmc.ncbi.nlm.nih.gov/articles/PMC4035446/#:~:text=substantially%20less%20than%203500%20kcal%2Flb7,far%20lower%20than%20Wishnofsky%E2%80%99s

Toate informatiile sunt preluate de pe site-ul ``National Library of Medicine`` [https://www.ncbi.nlm.nih.gov/]
