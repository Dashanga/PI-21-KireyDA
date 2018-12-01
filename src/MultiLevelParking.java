import java.util.ArrayList;


class MultiLevelParking
    {
        ///Список с уровнями парковки
        ArrayList<Parking<Vehicle>> parkingStages;

        ///Сколько мест на каждом уровне
        private final int countPlaces = 20;

        ///Конструктор
        ///<param name="countStages">Количествоуровенйпарковки</param>
        ///<param name="pictureWidth"></param>
        ///<param name="pictureHeight"></param>
        public MultiLevelParking(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new ArrayList<Parking<Vehicle>>();
            for (int i = 0; i < countStages; ++i)
            {
                parkingStages.add(new Parking<Vehicle>(countPlaces, pictureWidth, pictureHeight));
            }
        }

        ///Индексатор
        ///<param name="ind"></param>
        ///<returns></returns>
        public Parking<Vehicle> getValue(int ind) {
        	if (ind > -1 && ind < parkingStages.size())
            {
                return parkingStages.get(ind);
            }
            return null;
            
        }
}