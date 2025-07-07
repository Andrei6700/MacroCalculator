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
Factory pattern este implementat prin clasele factory abstracte și concrete:

- `DietPlanFactory`- clasa abstractă de bază
- `BulkPlanFactory` - pentru crearea paginii de bulk
- `CutPlanFactory` - pentru crearea paginii de cut  
- `MaintainPlanFactory` - pentru crearea paginii de menitnere

Este utilizata in `MainPage.cs`:
```csharp
  private void btnBulk_Click(object sender, EventArgs e)
        {
            var factory = new BulkPlanFactory();
            IDietPlanPage bulkPage = factory.CreatePage();
            bulkPage.ShowPage();
            this.Hide();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            var factory = new CutPlanFactory();
            IDietPlanPage cutPage = factory.CreatePage();
            cutPage.ShowPage();
            this.Hide();
        }

        private void btnMaintain_Click(object sender, EventArgs e)
        {
            var factory = new MaintainPlanFactory();
            IDietPlanPage maintainPage = factory.CreatePage();
            maintainPage.ShowPage();
            this.Hide();
        }
```


## Strategy Pattern
### Ce este Strategy Pattern (sursa: Gpt):
- Strategy Pattern este un pattern comportamental care permite definirea unei familii de algoritmi intercambiabili și alegerea unuia dintre ei la runtime​.
- Esența sa este că extrage variațiile unui algoritm în clase separate (strategie), astfel încât contextul (clasa client) să le poată utiliza pe toate prin aceeași interfață, comutând ușor între ele fără a modifica codul principal.

### Implementarea in cod:
- Strategy Pattern in aplicatie este folosit pentru calculul caloriilor in functie de obiectivul ales de catre utilizator (Bulk, Cut sau Mentinere).
- Clasele concrete:
    -  `ICalorieCalculator` = interfata pentru strategy
    -  `BulkCaloriesCalculator`= clasa pt surplus caloric
    -  `CutCaloriesCalculator` = clasa pentru deficit caloric
    -  `MaintenanceCaloriesCalculator` = clasa pentru mentinere

- Exemplu de folosire pentru Bulk
```c#
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
