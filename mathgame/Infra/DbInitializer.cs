using mathgame.Entities;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        // Perfis
        if (!context.Profiles.Any())
        {
            context.Profiles.AddRange(
                new ProfileEntity { Role = "ADMIN" },
                new ProfileEntity { Role = "PROFESSOR" },
                new ProfileEntity { Role = "STUDENT" }
            );
            context.SaveChanges();
        }

        if (!context.Users.Any())
        {
            var profile = context.Profiles.FirstOrDefault(x => x.Role == "ADMIN");
            
            context.Users.Add(new UserEntity(
                "dev-test",
                "dev-test@gmail.com",
                "Senha@123",
                profile
                ));
            context.SaveChanges();
        }

        // Dificuldades
        if (!context.Difficulties.Any())
        {
            context.Difficulties.AddRange(
                new DifficultyEntity { Title = "EASY" },
                new DifficultyEntity { Title = "MEDIUM" },
                new DifficultyEntity { Title = "HARD" }
            );
            context.SaveChanges();
        }

        // Operações
        if (!context.Operations.Any())
        {
            context.Operations.AddRange(
                new OperationEntity { Title = "ADDITION" },
                new OperationEntity { Title = "SUBTRACTION" },
                new OperationEntity { Title = "MULTIPLICATION" },
                new OperationEntity { Title = "DIVISION" }
            );
            context.SaveChanges();
        }

        // Atribuindo dificuldade às operações
        if (!context.OperationDifficulties.Any())
        {
            context.OperationDifficulties.AddRange(
                new OperationDifficultiesEntity(1, 1), 
                new OperationDifficultiesEntity(2, 1), 
                new OperationDifficultiesEntity(3, 1), 
                new OperationDifficultiesEntity(4, 1), 
                new OperationDifficultiesEntity(1, 2), 
                new OperationDifficultiesEntity(2, 2), 
                new OperationDifficultiesEntity(3, 2), 
                new OperationDifficultiesEntity(4, 2), 
                new OperationDifficultiesEntity(1, 3), 
                new OperationDifficultiesEntity(2, 3), 
                new OperationDifficultiesEntity(3, 3), 
                new OperationDifficultiesEntity(4, 3) 
                );
            context.SaveChanges();
        }

        // Questões
        if (!context.Questions.Any())
        {
            context.Questions.AddRange(
                // Adição - Fácil (OperationDifficultiesId = 1)
        new QuestionEntity("Quanto é 2 + 3?", "5", "4", "6", "3", 1),
        new QuestionEntity("Quanto é 1 + 6?", "7", "8", "6", "5", 1),
        new QuestionEntity("Quanto é 4 + 4?", "8", "9", "6", "7", 1),
        new QuestionEntity("Quanto é 5 + 3?", "8", "7", "9", "6", 1),
        new QuestionEntity("Quanto é 6 + 2?", "8", "7", "9", "6", 1),
        new QuestionEntity("Quanto é 3 + 5?", "8", "6", "7", "9", 1),
        new QuestionEntity("Quanto é 7 + 1?", "8", "7", "6", "9", 1),
        new QuestionEntity("Quanto é 0 + 9?", "9", "8", "10", "7", 1),
        new QuestionEntity("Quanto é 2 + 2?", "4", "5", "3", "6", 1),
        new QuestionEntity("Quanto é 1 + 1?", "2", "3", "4", "0", 1),

        // Subtração - Fácil (OperationDifficultiesId = 2)
        new QuestionEntity("Quanto é 5 - 2?", "3", "2", "4", "1", 2),
        new QuestionEntity("Quanto é 7 - 3?", "4", "5", "3", "6", 2),
        new QuestionEntity("Quanto é 9 - 4?", "5", "6", "4", "3", 2),
        new QuestionEntity("Quanto é 6 - 1?", "5", "4", "6", "3", 2),
        new QuestionEntity("Quanto é 8 - 3?", "5", "6", "4", "7", 2),
        new QuestionEntity("Quanto é 4 - 2?", "2", "1", "3", "0", 2),
        new QuestionEntity("Quanto é 3 - 1?", "2", "3", "1", "0", 2),
        new QuestionEntity("Quanto é 10 - 5?", "5", "4", "6", "3", 2),
        new QuestionEntity("Quanto é 6 - 3?", "3", "4", "2", "1", 2),
        new QuestionEntity("Quanto é 7 - 2?", "5", "6", "4", "3", 2),

        // Multiplicação - Fácil (OperationDifficultiesId = 3)
        new QuestionEntity("Quanto é 1 x 2?", "2", "3", "1", "4", 3),
        new QuestionEntity("Quanto é 2 x 2?", "4", "6", "2", "5", 3),
        new QuestionEntity("Quanto é 3 x 1?", "3", "2", "4", "1", 3),
        new QuestionEntity("Quanto é 2 x 4?", "8", "6", "10", "4", 3),
        new QuestionEntity("Quanto é 5 x 1?", "5", "4", "6", "3", 3),
        new QuestionEntity("Quanto é 0 x 3?", "0", "1", "3", "2", 3),
        new QuestionEntity("Quanto é 3 x 3?", "9", "6", "12", "8", 3),
        new QuestionEntity("Quanto é 4 x 2?", "8", "6", "10", "4", 3),
        new QuestionEntity("Quanto é 2 x 5?", "10", "8", "9", "6", 3),
        new QuestionEntity("Quanto é 1 x 7?", "7", "6", "8", "9", 3),

        // Divisão - Fácil (OperationDifficultiesId = 4)
        new QuestionEntity("Quanto é 6 ÷ 2?", "3", "2", "4", "5", 4),
        new QuestionEntity("Quanto é 9 ÷ 3?", "3", "2", "4", "5", 4),
        new QuestionEntity("Quanto é 8 ÷ 4?", "2", "3", "4", "1", 4),
        new QuestionEntity("Quanto é 10 ÷ 2?", "5", "6", "4", "3", 4),
        new QuestionEntity("Quanto é 12 ÷ 3?", "4", "3", "5", "6", 4),
        new QuestionEntity("Quanto é 4 ÷ 2?", "2", "1", "3", "0", 4),
        new QuestionEntity("Quanto é 2 ÷ 1?", "2", "1", "0", "3", 4),
        new QuestionEntity("Quanto é 15 ÷ 5?", "3", "5", "2", "6", 4),
        new QuestionEntity("Quanto é 6 ÷ 3?", "2", "1", "3", "4", 4),
        new QuestionEntity("Quanto é 7 ÷ 1?", "7", "6", "5", "8", 4),
        
        // Adição - Médio (OperationDifficultiesId = 5)
    new QuestionEntity("Quanto é 12 + 8?", "20", "18", "21", "22", 5),
    new QuestionEntity("Quanto é 15 + 7?", "22", "20", "23", "24", 5),
    new QuestionEntity("Quanto é 23 + 16?", "39", "38", "37", "40", 5),
    new QuestionEntity("Quanto é 14 + 9?", "23", "22", "21", "24", 5),
    new QuestionEntity("Quanto é 11 + 13?", "24", "25", "23", "22", 5),
    new QuestionEntity("Quanto é 17 + 12?", "29", "30", "28", "27", 5),
    new QuestionEntity("Quanto é 18 + 15?", "33", "34", "32", "31", 5),
    new QuestionEntity("Quanto é 21 + 14?", "35", "34", "36", "33", 5),
    new QuestionEntity("Quanto é 25 + 10?", "35", "34", "36", "33", 5),
    new QuestionEntity("Quanto é 19 + 11?", "30", "29", "28", "31", 5),

    // Subtração - Médio (OperationDifficultiesId = 6)
    new QuestionEntity("Quanto é 20 - 7?", "13", "12", "14", "15", 6),
    new QuestionEntity("Quanto é 18 - 9?", "9", "8", "10", "7", 6),
    new QuestionEntity("Quanto é 25 - 11?", "14", "13", "12", "15", 6),
    new QuestionEntity("Quanto é 30 - 16?", "14", "13", "15", "12", 6),
    new QuestionEntity("Quanto é 27 - 8?", "19", "18", "17", "20", 6),
    new QuestionEntity("Quanto é 22 - 13?", "9", "8", "10", "7", 6),
    new QuestionEntity("Quanto é 35 - 17?", "18", "19", "16", "17", 6),
    new QuestionEntity("Quanto é 19 - 6?", "13", "14", "12", "15", 6),
    new QuestionEntity("Quanto é 28 - 15?", "13", "14", "12", "11", 6),
    new QuestionEntity("Quanto é 40 - 25?", "15", "16", "14", "13", 6),

    // Multiplicação - Médio (OperationDifficultiesId = 7)
    new QuestionEntity("Quanto é 4 x 6?", "24", "20", "22", "26", 7),
    new QuestionEntity("Quanto é 5 x 5?", "25", "20", "30", "24", 7),
    new QuestionEntity("Quanto é 3 x 7?", "21", "20", "18", "22", 7),
    new QuestionEntity("Quanto é 6 x 4?", "24", "20", "22", "26", 7),
    new QuestionEntity("Quanto é 8 x 3?", "24", "25", "23", "26", 7),
    new QuestionEntity("Quanto é 9 x 2?", "18", "16", "17", "19", 7),
    new QuestionEntity("Quanto é 7 x 5?", "35", "30", "40", "34", 7),
    new QuestionEntity("Quanto é 6 x 6?", "36", "35", "34", "38", 7),
    new QuestionEntity("Quanto é 8 x 4?", "32", "30", "34", "33", 7),
    new QuestionEntity("Quanto é 3 x 9?", "27", "26", "28", "25", 7),

    // Divisão - Médio (OperationDifficultiesId = 8)
    new QuestionEntity("Quanto é 18 ÷ 3?", "6", "5", "4", "7", 8),
    new QuestionEntity("Quanto é 21 ÷ 7?", "3", "2", "4", "5", 8),
    new QuestionEntity("Quanto é 24 ÷ 4?", "6", "5", "7", "8", 8),
    new QuestionEntity("Quanto é 30 ÷ 5?", "6", "5", "4", "7", 8),
    new QuestionEntity("Quanto é 36 ÷ 6?", "6", "5", "7", "8", 8),
    new QuestionEntity("Quanto é 32 ÷ 4?", "8", "6", "7", "9", 8),
    new QuestionEntity("Quanto é 45 ÷ 9?", "5", "4", "6", "7", 8),
    new QuestionEntity("Quanto é 40 ÷ 8?", "5", "6", "4", "7", 8),
    new QuestionEntity("Quanto é 27 ÷ 3?", "9", "8", "7", "6", 8),
    new QuestionEntity("Quanto é 42 ÷ 6?", "7", "6", "8", "5", 8),

    // Adição - Difícil (OperationDifficultiesId = 9)
    new QuestionEntity("Quanto é 78 + 56?", "134", "132", "136", "130", 9),
    new QuestionEntity("Quanto é 123 + 89?", "212", "210", "215", "208", 9),
    new QuestionEntity("Quanto é 145 + 67?", "212", "211", "213", "210", 9),
    new QuestionEntity("Quanto é 199 + 88?", "287", "286", "285", "288", 9),
    new QuestionEntity("Quanto é 302 + 119?", "421", "420", "422", "419", 9),
    new QuestionEntity("Quanto é 450 + 275?", "725", "720", "730", "715", 9),
    new QuestionEntity("Quanto é 398 + 347?", "745", "740", "748", "750", 9),
    new QuestionEntity("Quanto é 516 + 288?", "804", "802", "800", "806", 9),
    new QuestionEntity("Quanto é 632 + 359?", "991", "990", "992", "989", 9),
    new QuestionEntity("Quanto é 721 + 468?", "1189", "1190", "1188", "1191", 9),

    // Subtração - Difícil (OperationDifficultiesId = 10)
    new QuestionEntity("Quanto é 150 - 87?", "63", "62", "64", "65", 10),
    new QuestionEntity("Quanto é 320 - 158?", "162", "160", "161", "163", 10),
    new QuestionEntity("Quanto é 507 - 249?", "258", "259", "257", "260", 10),
    new QuestionEntity("Quanto é 689 - 372?", "317", "316", "318", "319", 10),
    new QuestionEntity("Quanto é 834 - 418?", "416", "417", "415", "418", 10),
    new QuestionEntity("Quanto é 900 - 457?", "443", "442", "444", "445", 10),
    new QuestionEntity("Quanto é 1000 - 627?", "373", "374", "372", "375", 10),
    new QuestionEntity("Quanto é 786 - 398?", "388", "387", "389", "386", 10),
    new QuestionEntity("Quanto é 635 - 219?", "416", "417", "415", "414", 10),
    new QuestionEntity("Quanto é 728 - 459?", "269", "270", "268", "271", 10),

    // Multiplicação - Difícil (OperationDifficultiesId = 11)
    new QuestionEntity("Quanto é 12 x 13?", "156", "154", "158", "160", 11),
    new QuestionEntity("Quanto é 17 x 19?", "323", "321", "325", "327", 11),
    new QuestionEntity("Quanto é 24 x 18?", "432", "430", "434", "436", 11),
    new QuestionEntity("Quanto é 29 x 16?", "464", "462", "466", "468", 11),
    new QuestionEntity("Quanto é 21 x 23?", "483", "482", "484", "485", 11),
    new QuestionEntity("Quanto é 36 x 15?", "540", "542", "538", "536", 11),
    new QuestionEntity("Quanto é 27 x 19?", "513", "511", "514", "510", 11),
    new QuestionEntity("Quanto é 32 x 22?", "704", "702", "706", "700", 11),
    new QuestionEntity("Quanto é 45 x 17?", "765", "763", "767", "770", 11),
    new QuestionEntity("Quanto é 38 x 14?", "532", "534", "530", "536", 11),

    // Divisão - Difícil (OperationDifficultiesId = 12)
    new QuestionEntity("Quanto é 144 ÷ 12?", "12", "11", "13", "14", 12),
    new QuestionEntity("Quanto é 169 ÷ 13?", "13", "12", "14", "15", 12),
    new QuestionEntity("Quanto é 225 ÷ 15?", "15", "14", "16", "17", 12),
    new QuestionEntity("Quanto é 560 ÷ 14?", "40", "38", "42", "39", 12),
    new QuestionEntity("Quanto é 624 ÷ 26?", "24", "23", "25", "22", 12),
    new QuestionEntity("Quanto é 729 ÷ 27?", "27", "26", "28", "29", 12),
    new QuestionEntity("Quanto é 816 ÷ 24?", "34", "33", "35", "36", 12),
    new QuestionEntity("Quanto é 935 ÷ 17?", "55", "54", "56", "57", 12),
    new QuestionEntity("Quanto é 1008 ÷ 28?", "36", "35", "37", "38", 12),
    new QuestionEntity("Quanto é 1210 ÷ 22?", "55", "54", "56", "57", 12)        
                );
            context.SaveChanges();
        }
    }
}