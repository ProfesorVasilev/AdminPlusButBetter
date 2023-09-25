namespace AdminPlusButBetter
{
    internal class Program
    {
        //TODO
        //add note dates ama me murzi i e bukvalno sushtoto kato s grades 

        static void Main(string[] args)
        {
            Dictionary<int, Grade> gradesDict = new Dictionary<int, Grade>();
            Dictionary<int, Note> notesDict = new Dictionary<int, Note>();
            List<Grade> grades = new List<Grade>();
            List<Note> notes = new List<Note>();

            while (true)
            {
                Console.Write("Username: ");
                string user = Console.ReadLine();

                Console.Write("Password: ");
                string stringPass = Console.ReadLine();
                bool parsed = int.TryParse(stringPass, out int pass);
                while (!parsed || stringPass.Length != 4)
                {
                    ErrorMsg("Password has to be 4 digits");
                    Console.Write("Password: ");
                    stringPass = Console.ReadLine();
                    parsed = int.TryParse(stringPass, out pass);
                }

                if (user == "teacher" && pass == 1357)
                {
                    SuccessMsg("Welcome, Mr.Teacher!");
                    bool wantsToExit = false;

                    while (!wantsToExit)
                    {
                        Console.Write("Select activity - manage grades / manage notes / exit: ");
                        string activity = Console.ReadLine();
                        switch (activity)
                        {
                            case "manage grades":
                                Console.WriteLine("browse / add / delete / exit : ");
                                string optionG = Console.ReadLine();
                                switch (optionG)
                                {
                                    case "browse":
                                        ShowGrades(grades, "teacher");
                                        break;

                                    case "add":
                                        AddGrade(grades, gradesDict);
                                        break;

                                    case "delete":
                                        DeleteGrade(grades, gradesDict);
                                        break;

                                    case "exit":
                                        wantsToExit = true;
                                        break;

                                    default:
                                        ErrorMsg("Invalid option. Please try again.");
                                        break;
                                }
                                break;

                            case "manage notes":
                                Console.WriteLine("browse / add / delete / exit : ");
                                string optionN = Console.ReadLine();
                                switch (optionN)
                                {
                                    case "browse":
                                        ShowNotes(notes, "teacher");
                                        break;

                                    case "add":
                                        AddNote(notes, notesDict);
                                        break;

                                    case "delete":                                    
                                        DeleteNote(notes, notesDict);
                                        break;

                                    case "exit":
                                        wantsToExit = true;
                                        break;

                                    default:
                                        ErrorMsg("Invalid option. Please try again.");
                                        break;
                                }
                                break;

                            default:
                                ErrorMsg("Invalid option. Please try again.");
                                break;
                        }
                    }
                }

                else if (user == "student" && pass == 0000)
                {
                    SuccessMsg("Welcome, Mr.Student!");
                    bool wantsToExit = false;
                    while (!wantsToExit) 
                    {                        
                        Console.Write("grades / notes / schedule / exit: ");
                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "grades":
                                ShowGrades(grades, "student");
                                break;

                            case "notes":
                                ShowNotes(notes, "student");
                                break;

                            case "schedule":
                                PrintSchedule();
                                break;

                            case "exit":
                                wantsToExit =true;
                                break;

                            default:
                                ErrorMsg("Invalid option. Please try again.");
                                break;
                        }
                    }
                }

                else
                {
                    ErrorMsg("Invalid password or username. Please try again.");
                }
            }
        }
        //methods 


        private static void AddGrade(List<Grade> grades, Dictionary<int, Grade> dict)
        {
            bool addAnotherGrade = true;
            while (addAnotherGrade)
            {
                int val = GetInt("Value has to be a number between 2 and 6.", "Whats the value of the grade: ", 2, 6);

                Console.Write("Whats the reason for the grade: ");
                string reason = Console.ReadLine();

                int day = GetInt("Day has to be a number between 1 and 30.", "Whats the day of the grade: ", 1, 30);

                int month = GetInt("Month has to be a number between 1 and 12.", "Whats the month of the grade: ", 1, 12);

                int year = GetInt("Year has to be a number either this or last year.", "Whats the year of the grade: ", 2022, 2023);

                Grade gr = new Grade(val, reason, day, month, year, dict.Count);
                grades.Add(gr);
                dict.Add(gr.id, gr);
                SuccessMsg("Successfully added grade");

                Console.WriteLine("Would you like to add another grade?");
                string response;
                bool validResponse = false;
                while (!validResponse)
                {
                    response = Console.ReadLine();
                    if (response == "yes")
                    {
                        validResponse = true;
                        continue;
                    }
                    else if (response == "no")
                    {
                        validResponse = true;
                        addAnotherGrade = false;
                    }
                    else
                    {
                        ErrorMsg("Please enter a valid response! Would you like to add another grade?");
                    }
                }
            }
        }

        public static void ShowGrades(List<Grade> grades, string role)
        {
            if (grades.Count == 0)
            {
                ErrorMsg("There are no grades currently!");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Current grades:");
            foreach (Grade g in grades)
            {
                Console.WriteLine("Grade: " + g.value);
                Console.WriteLine("Desciption: " + g.reason);
                Console.WriteLine("Date: " + g.fullDate);
                if (role == "teacher")
                {
                    Console.WriteLine("Id: " + g.id);
                }
                Console.WriteLine("------------------------------------");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DeleteGrade(List<Grade> grades, Dictionary<int, Grade> gradesDict)
        {
            int id = GetInt("The id has to be a valid grade id!", "Please enter the id of the grade you'd like to remove: ", 0, grades.Count);
            foreach (var item in gradesDict)
            {
                if (id == item.Key)
                {
                    grades.Remove(item.Value);
                    SuccessMsg("Removed grade " + id);
                    break;
                }
            }
        }
        private static void AddNote(List<Note> notes, Dictionary<int, Note> dict)
        {
            bool addAnotherNote = true;
            while (addAnotherNote)
            {
                Console.Write("Whats the title of the note: ");
                string title = Console.ReadLine();

                Console.Write("Whats the description of the note: ");
                string desc = Console.ReadLine();

                Note note = new Note(title, desc, dict.Count);
                notes.Add(note);
                dict.Add(note.id, note);
                SuccessMsg("Successfully added note");

                Console.WriteLine("Would you like to add another note?");
                string response;
                bool validResponse = false;

                while (!validResponse)
                {
                    response = Console.ReadLine();
                    if (response == "yes")
                    {
                        validResponse = true;
                        continue;
                    }
                    else if (response == "no")
                    {
                        validResponse = true;
                        addAnotherNote = false;
                    }
                    else
                    {
                        ErrorMsg("Please enter a valid response! Would you like to add another note?");
                    }
                }
            }
        }
        public static void ShowNotes(List<Note> notes, string role)
        {
            if (notes.Count == 0)
            {
                ErrorMsg("There are no notes currently!");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Current notes:");
            foreach (Note n in notes)
            {
                Console.WriteLine("Title: " + n.title);
                Console.WriteLine("Desciption: " + n.description);
                if (role == "teacher")
                {
                    Console.WriteLine("Id: " + n.id);
                }
                Console.WriteLine("------------------------------------");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DeleteNote(List<Note> notes, Dictionary<int, Note> notesDict)
        {
            int id = GetInt("The id has to be a valid note id!", "Please enter the id of the note you'd like to remove: ", 0, notes.Count);
            foreach (var item in notesDict)
            {
                if (id == item.Key)
                {
                    notes.Remove(item.Value);
                    SuccessMsg("Removed note " + id);
                    break;
                }
            }
        }

        public static void ErrorMsg(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void SuccessMsg(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static int GetInt(string errorMsg, string shortMsg, int min, int max)
        {
            Console.Write(shortMsg);
            bool parsed = int.TryParse(Console.ReadLine(), out int value);
            while (!parsed || value < min || value > max)
            {
                ErrorMsg(errorMsg);
                Console.Write(shortMsg);
                parsed = int.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }
        public static void PrintSchedule()
        {
            SuccessMsg("Here is your schedule for the week:");
            Console.WriteLine("|Monday | Tuesday | Wednesday | Thursday | Friday |");
            Console.WriteLine("|-------------------------------------------------|");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|       |         |           |          |        | ");
            Console.WriteLine("|-------------------------------------------------|");

        }
    }
}