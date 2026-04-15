using System.Collections.Generic;

namespace hakaton_yz_api.Models
{
    public enum RailwayBranch
    {
        Південно_Західна,
        Львівська,
        Одеська,
        Південна,
        Придніпровська,
    }

    public enum StationType
    {
        ЦентральнийВузол,
        ЗалізничнаСтанція,
    }

    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RailwayBranch Branch { get; set; }
        public StationType Type { get; set; }
    }

    public static class StationData
    {
        public static List<Station> AllStations = new List<Station>
        {
            new Station { Id = 1, Name = "Київ-Пасажирський", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЦентральнийВузол },
            new Station { Id = 2, Name = "Дарниця", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 3, Name = "Київ-Волинський", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 4, Name = "Київ-Деміївський", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 5, Name = "Київ-Товарний", Branch = RailwayBranch.Південно_Західна, Type = StationType.ЗалізничнаСтанція },

            new Station { Id = 6, Name = "Львів-Головний", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 7, Name = "Стрий", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 8, Name = "Чоп", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 9, Name = "Мостинська 2", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 10, Name = "Ковель", Branch = RailwayBranch.Львівська, Type = StationType.ЗалізничнаСтанція },

            new Station { Id = 11, Name = "Одеса-Головна", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 12, Name = "Чорноморськ-Порт", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 13, Name = "Ізмаїл", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 14, Name = "Роздільна", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 15, Name = "Помічна", Branch = RailwayBranch.Одеська, Type = StationType.ЗалізничнаСтанція },

            new Station { Id = 16, Name = "Харків-Пасажирський", Branch = RailwayBranch.Південна, Type = StationType.ЦентральнийВузол },
            new Station { Id = 17, Name = "Мерефа", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 18, Name = "Лозова", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 19, Name = "Куп'янськ", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 20, Name = "Слов'янськ", Branch = RailwayBranch.Південна, Type = StationType.ЗалізничнаСтанція },

            new Station { Id = 21, Name = "Дніпро-Головний", Branch = RailwayBranch.Придніпровська, Type = StationType.ЦентральнийВузол },
            new Station { Id = 22, Name = "Запоріжжя-1", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 23, Name = "Кривий Ріг-Головний", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 24, Name = "Павлоград", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція },
            new Station { Id = 25, Name = "Синельникове", Branch = RailwayBranch.Придніпровська, Type = StationType.ЗалізничнаСтанція }
        };
    }
}
