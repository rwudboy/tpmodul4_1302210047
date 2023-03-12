internal class Program
{
    public enum pintuState { Terkunci,Terbuka}
    public enum Triger { KunciPintu,BukaPintu}
    public pintuState saatIni = pintuState.Terkunci;
    enum Kelurahan
    {
        Batununggal,
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja
    }
    private static int KodePos(Kelurahan inputK)
    {
        int[] outKodePos = {40266,40287,40267, 40256 , 40287, 40286, 40286 , 40286 , 40272 , 40274, 40273 };
        return outKodePos[(int)inputK];
    }
    class DoorMachine
    {
        
        public class Transisi
        {
            public pintuState stateAwal;
            public pintuState stateAkhir;
            public Triger triger;
            
            public Transisi(pintuState stateAwal, pintuState stateAkhir,Triger triger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.triger = triger;
            }
            
        }
        Transisi[] transisi =
            {
                new Transisi(pintuState.Terkunci,pintuState.Terkunci,Triger.KunciPintu),
                new Transisi(pintuState.Terkunci,pintuState.Terbuka,Triger.BukaPintu),
                new Transisi(pintuState.Terbuka,pintuState.Terbuka,Triger.BukaPintu),
                new Transisi(pintuState.Terbuka,pintuState.Terkunci,Triger.KunciPintu),
            };
        private pintuState saatIni;

        private pintuState dapatBerikutnya(pintuState stateAwal, Triger triger)
        {
            pintuState stateAkhir = stateAwal;
            for (int i = 0; i < transisi.Length; i++)
            {
                Transisi berubah = transisi[i];
                if (stateAwal == berubah.stateAwal && triger == berubah.triger)
                {
                    stateAkhir = berubah.stateAkhir;
                }
            }
            return stateAkhir;
        }
        public void aktifTriger(Triger triger)
        {
            saatIni = dapatBerikutnya(saatIni, triger);
            if (saatIni == pintuState.Terkunci)
            {
                Console.WriteLine("Pintu terkunci");
            }
            else if (saatIni == pintuState.Terbuka)
            {
                Console.WriteLine("Pintu tidak terkunci");
            }
        }
    }
    private static void Main(string[] args)
    {
        Kelurahan kelurahan = Kelurahan.Samoja;
        int getKodePos = KodePos(kelurahan);
        Console.WriteLine("kelurahan "+kelurahan+"kode pos "+getKodePos);
        DoorMachine pintu = new DoorMachine();
        pintu.aktifTriger(Triger.KunciPintu);
        pintu.aktifTriger(Triger.BukaPintu);


    }
}