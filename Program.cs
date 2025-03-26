// See https://aka.ms/new-console-template for more information

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public String Username;

    public SayaTubeUser(String username)
    {
        if (username.Length > 100)
        {
            throw new ArgumentException("Eror -- Username harus kurang dari 100 karakter");
        }
        if (username == null)
        {
            throw new ArgumentException("Eror -- Username tidak boleh null");
        }

        this.Username = username;
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int sum = 0;
        foreach (var item in uploadedVideos)
        {
            checked
            {
                sum += item.getPlayCount();
            }
        }
        return sum;
    }
    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
        {
            throw new ArgumentException("Eror -- Video tidak boleh null");
        }

        if (video.getPlayCount() > int.MaxValue)
        {
            throw new ArgumentException("Eror -- Playcount kebanyakan");
        }
        uploadedVideos.Add(video);
    }
    public void PrintAllVideoPlaycount() 
    {
        Console.WriteLine("User: " + this.Username);

        for (int i = 1; i <= uploadedVideos.Count && i < 9; i++)
        {
            Console.WriteLine("Video "+ i +" judul: " + uploadedVideos[i-1].getJudul());
        }
    }

}

class SayaTubeVideo
{
    private int id;
    private String title;
    private int playCount;

    public SayaTubeVideo(String title)
    {
        if (title.Length > 200)
        {
            throw new ArgumentException("Eror -- Title harus kurang dari 200 karakter");
        }

        if (title == null)
        {
            throw new ArgumentException("Eror -- Title tidak boleh null");
        }

        this.title = title;
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.playCount = 0;
    }

    public void IncreasePlayCount(int increaseNumb)
    {
        if (increaseNumb > 25000000)
        {
            throw new ArgumentException("Eror -- increaseNumb tidak boleh lebih dari 25.000.000");
        }

        if (increaseNumb < 0)
        {
            throw new ArgumentException("Eror -- increaseNumb tidak boleh negatif");
        }
        checked
        {
            this.playCount += increaseNumb;
        }
    }
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID :"+ this.id);
        Console.WriteLine("Title :" + this.title);
        Console.WriteLine("Play Count :" + this.playCount + "\n");
    }

    public int getPlayCount()
    {
        return this.playCount;
    }

    public String getJudul()
    {
        return this.title;
    }
}

class Program
{
    static void Main()
    {
        SayaTubeVideo vid1 = new SayaTubeVideo("Review Film \"Titanic\" oleh Albert Febrian");
        SayaTubeVideo vid2 = new SayaTubeVideo("Review Film \"The Nun\" oleh Albert Febrian");
        SayaTubeVideo vid3 = new SayaTubeVideo("Review Film \"Ocong\" oleh Albert Febrian");
        SayaTubeVideo vid4 = new SayaTubeVideo("Review Film \"Apenger\" oleh Albert Febrian");
        SayaTubeVideo vid5 = new SayaTubeVideo("Review Film \"Batman\" oleh Albert Febrian");
        SayaTubeVideo vid6 = new SayaTubeVideo("Review Film \"Superman\" oleh Albert Febrian");
        SayaTubeVideo vid7 = new SayaTubeVideo("Review Film \"Kucing Hitam\" oleh Albert Febrian");
        SayaTubeVideo vid8 = new SayaTubeVideo("Review Film \"Perahu Kertas\" oleh Albert Febrian");
        SayaTubeVideo vid9 = new SayaTubeVideo("Review Film \"100 Days\" oleh Albert Febrian");
        SayaTubeVideo vid10 = new SayaTubeVideo("Review Film \"The Meg\" oleh Albert Febrian");

        SayaTubeUser user1 = new SayaTubeUser("Albert");

        //Test method IncreasePlayCount dan PrintVideoDetails
        vid1.IncreasePlayCount(1);
        vid1.PrintVideoDetails();

        vid2.IncreasePlayCount(2);
        vid2.PrintVideoDetails();

        vid3.IncreasePlayCount(3);
        vid3.PrintVideoDetails();

        vid4.IncreasePlayCount(4);
        vid4.PrintVideoDetails();

        vid5.IncreasePlayCount(5);
        vid5.PrintVideoDetails();

        vid6.IncreasePlayCount(6);
        vid6.PrintVideoDetails();

        vid7.IncreasePlayCount(7);
        vid7.PrintVideoDetails();

        vid8.IncreasePlayCount(8);
        vid8.PrintVideoDetails();

        vid9.IncreasePlayCount(9);
        vid9.PrintVideoDetails();

        vid10.IncreasePlayCount(10);
        vid10.PrintVideoDetails();

        //Test method addVideo dan getTotalCount
        user1.AddVideo(vid1);
        user1.AddVideo(vid2);
        user1.AddVideo(vid3);
        user1.AddVideo(vid4);
        user1.AddVideo(vid5);
        user1.AddVideo(vid6);
        user1.AddVideo(vid7);
        user1.AddVideo(vid8);
        user1.AddVideo(vid9);
        user1.AddVideo(vid10);

        Console.WriteLine("User: "+ user1.Username +" memiliki total playcount sebanyak "+user1.GetTotalVideoPlayCount() + "\n \n");

        //Test printallvideoplaycpunt
        user1.PrintAllVideoPlaycount();

        Console.WriteLine("\n \n \n");
        //Judul video memiliki panjang maksimal 200 karakter.
        try
        {
            SayaTubeVideo vid11 = new SayaTubeVideo(new string('A', 202));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        //Input penambahan play count maksimal 25.000.000 per panggilan method-nya
        try
        {
            vid1.IncreasePlayCount(25000001);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        //Nama username memiliki panjang maksimal 100 karakter.

        try
        {
            SayaTubeUser user2 = new SayaTubeUser(new string('A', 101));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        //Video yang ditambahkan tidak berupa null.
        try
        {
            user1.AddVideo(null);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        //testing overflow
        try
        {
            SayaTubeUser user2 = new SayaTubeUser("Febrian");
            SayaTubeVideo vid20 = new SayaTubeVideo("Review Film \"Dugong Berenang\" oleh Albert Febrian");
            vid20.IncreasePlayCount(20000000);
            for (int i = 0; i < 1000000; i++)
            {
                user2.AddVideo(vid20);
            }
            user2.GetTotalVideoPlayCount();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }


        //Jumlah video maksimal yang di-print adalah 8 pada method PrintAllVideoPlaycount()
        try
        {
            Console.WriteLine("\n \n \n");
            user1.PrintAllVideoPlaycount();
            //disini hanya terprint 8 walaupun didalamnya ada 10
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
