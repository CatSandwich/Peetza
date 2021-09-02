using Data;
using UnityEngine;

namespace Station.Maker
{
    public class MakerStationButton : MonoBehaviour
    {
        public MakerStation Maker;
        public Pizza.SizeEnum Size;
        
        private void OnMouseDown()
        {
            Maker.MakePizza(Size);
        }
    }
}
