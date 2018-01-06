using System;

namespace Training3.Model
{
    public class CargoItem
    {
        string[] names = new string[] { "Window","Door","PC","TV","Radio","Lamp","Carpet","Smartphone" };
        float[] weights = new float[] { 50.55f, 86.2f, 12.0f, 30.55f, 2.33f, 0.09f, 11.98f, 0.2f };

        public string name { get; set; }
        public int amount { get; set; }
        public float weight { get; set; }
        static Random rnd = new Random();

        public CargoItem()
        {
            int i = rnd.Next(0, 7);
            this.name = names[i];
            this.amount = rnd.Next(1,100);
            this.weight = weights[i]*this.amount;
            
        }
    }
}
