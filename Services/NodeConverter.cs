namespace YandexRasp {
    public static class NodeConverter {

        public static string ProcessDate(this DateTime date) {
            return $"{date.Year}-{date.Month}-{date.Day}";
        }
        public static IEnumerable<RaspDBModel> ToDBModels(this IEnumerable<RaspModel> input) {

            foreach (RaspModel model in input) {

                yield return new RaspDBModel() {
                    From = model.From,
                    To = model.To,
                    Date = model.Date,
                    FlightNo = model.FlightNo
                };
            }
        }
        
        public static IEnumerable<RaspModel> ToModels(this IQueryable<RaspDBModel> input) {

            foreach (RaspDBModel model in input) {

                yield return new RaspModel() {
                    From = model.From,
                    To = model.To,
                    Date = model.Date,
                    FlightNo = model.FlightNo
                };
            }
        }
    }
}