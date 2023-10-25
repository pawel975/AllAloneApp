using AllAloneApp;
using NUnit.Framework;
using System;
public class ExampleTest
{
    [Test]
    public void Ex1()
    {
        char[][] house =
        {
            "  o                o        #######".ToCharArray(),
            "###############             #     #".ToCharArray(),
            "#             #        o    #     #".ToCharArray(),
            "#  X          ###############     #".ToCharArray(),
            "#                                 #".ToCharArray(),
            "###################################".ToCharArray()
        };
        Assert.AreEqual(true, Program.AllAlone(house));
    }

    [Test]
    public void Ex2()
    {
        char[][] house =
        {
            "#################             ".ToCharArray(),
            "#     o         #   o         ".ToCharArray(),
            "#          ######        o    ".ToCharArray(),
            "####       #                  ".ToCharArray(),
            "   #       ###################".ToCharArray(),
            "   #                         #".ToCharArray(),
            "   #                  X      #".ToCharArray(),
            "   ###########################".ToCharArray()
        };
        Assert.AreEqual(false, Program.AllAlone(house));
    }
}