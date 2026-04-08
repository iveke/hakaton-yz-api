using System.Collections.Generic;

namespace hakaton_yz_api.Models
{
    public enum RailwayBranch
    {
        Південно_Західна, // Філія 1
        Львівська,        // Філія 2
        Одеська,          // Філія 3
        Південна,         // Філія 4
        Придніпровська    // Філія 5
    }

    public enum StationType
    {
        ЦентральнийВузол,
        ЗалізничнаСтанція
    }

    public class Station
    {
        public string Name { get; set; } = string.Empty;
        public RailwayBranch Branch { get; set; }
        public StationType Type { get; set; }
    }

    public static class StationData
    {
        public static List<Station> AllStations = new List<Station>
        {
            // Філія 1: Південно-Західна залізниця
            new Station { Name = "Київ-Пасажирський", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЦентральнийВузол },
            new Station { Name = "Дарниця", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Київ-Волинський", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Київ-Деміївський", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Київ-Товарний", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },

            // Філія 2: Львівська
            new Station { Name = "Львів-Головний", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Стрий", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Чоп", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Мостинська 2", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Ковель", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },

            // Філія 3: Одеська
            new Station { Name = "Одеса-Головна", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Чорноморськ-Порт", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Ізмаїл", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Роздільна", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Помічна", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },

            // Філія 4: Південна
            new Station { Name = "Харків-Пасажирський", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Харків-Сортувальний", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Лозова", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Полтава-Київська", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Кременчук", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },

            // Філія 5: Придніпровська
            new Station { Name = "Дніпро-Головний", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Нижньодніпровськ", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Кам'янське", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Нікополь", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція },
            new Station { Name = "Апостолове", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція }
        };
    }
}
