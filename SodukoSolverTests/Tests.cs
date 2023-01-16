using SodukoSolver;
using SodukoSolver.Exceptions;
using SodukoSolver.IO;
using SodukoSolver.Parsers;
using SodukoSolver.Validations;

namespace SodukoSolverTests
{
    [TestClass]
    public class Tests
    {
        public string CheckString(string board)
        {
            if (board == "exit")
            {
                return board;
            }
            if (!Validator.AreDimensionsValid(board))
            {
                string message = string.Format("String size {0} doesnt represent supported board dimensions ", board.Length);
                message += Config.SupportedDimensionsString;
                throw new DimensionsOfBoardNotValidException(message);
            }
            char potentialValidChar = Validator.AreAllCharsValid(board);
            if (potentialValidChar != ' ')
            {
                string message = string.Format("Character '{0}' is not valid in this soduko grid", potentialValidChar);
                message += string.Format("\nIn this grid the valid characters are from '0' to '{0}'", (char)(Math.Sqrt(board.Length) + '0'));
                throw new CharNotValidException(message);
            }
            string potentialMessage = Validator.IsGridValid(board);
            if (Validator.IsGridValid(board) != "")
            {
                string message = potentialMessage;
                throw new GridNotValidException(message);
            }

            return board;
        }

        public string BaseTestFunction(string input)
        {
            /// <summary>
            /// This function is the entry point to my application and in charge of combining all classes, functions and modules into a working program.
            /// </summary>
            /// <param>
            /// args - in case i want to enter things from command line (not used)
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Parser p = new Parser();
            SodukoSolver.Timer timer = new SodukoSolver.Timer();
            Solver s = new Solver();
            Grid g = new Grid();
            input = CheckString(input);
            if (input == "exit")
            {
                ApplicationGeneralMessagesPrinter.PrintGoodByeMessage();
                return input;
            }
            g.UpdateGrid(p.ParseString(input, (int)Math.Sqrt(input.Length)));
            timer.start();
            s.Solve(g);
            
            timer.stop();

            timer.showTimePassed();
            return g.ConvertGridToString();

        }
        // Legal grids
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("1",
               BaseTestFunction("0"));

        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("1234341221434321",
               BaseTestFunction("0000000000000000"));

        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("123456789789123456456789123312845967697312845845697312231574698968231574574968231",
               BaseTestFunction("000000000000000000000000000000000000000000000000000000000000000000000000000000000"));

        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual("123456789:;<=>?@9:;<1234=>?@56785678=>?@12349:;<=>?@9:;<5678123431427586;9>:?<@=;9>:3142?<@=75867586?<@=3142;9>:?<@=;9>:7586314224136857:?9;<@=>:?9;2413<@=>68576857<@=>2413:?9;<@=>:?9;6857241343218765>;:9@=<?>;:94321@=<?87658765@=<?4321>;:9@=<?>;:987654321",
               BaseTestFunction("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));

        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual("123456789:;<=>?@ABCDEFGHI;<=>?12345@ABCDFGEHI6789:6789:HIFEG12345;<=>?@ABCDGFEIH@ABCD6789:12345;<=>?@ABCD;<=>?HEGFI6789:123453152>C@D7;B?EHG8:IF<49A=648:6B31GH2=FI<>9@C;A5?DE7H?I7<459=631@A2BD>EG8:F;C9C;DE8FIA>45:7631?=2BH@<G=GAF@:?EB<89D;C45H7631>I2251?3>=AI8G@C:B<H;D974E6F7@6;42B153<HA8F>EG:=DIC?9<IGE8746;92D153A?FBC>=H:@>DCH9FG:@E746?=2I153<8;ABA:FB=<H?DC>I;E97468@2G153C6412IE;<HDB9G8?>@AF:573=5=937A8214FCHI;:BDGE?6<@>?BDGA5673@:>214C=9<HFEI8;F><@;B:C?=5673EI8214AD9GH:EH8ID9>GF?=<@A5673;CB214B3251?D48IA:F=HG;<@>9C67EI47=693@21CG>D<EF:?8H;5BAD;?<CG>567E3421H9AIB=@:F889@AFECH:BI;567=3421G>?D<EH>:G=;<FA98?B@DC567I3421",
               BaseTestFunction("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));

        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual("376594281495821376812376459238749165169285743547163892924638517653417928781952634",
               BaseTestFunction("370590001005800000010306400208040065009000700540060802004608010000007900700052034"));

        }
        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual("364817259219365487758429631475236918926581743183794562842953176591678324637142895",
               BaseTestFunction("000010009000000080058020001075006000920000043000700560800050170090000000600040000"));

        }
        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual("472613859139578426856294137791425368625387914384169572243956781917832645568741293",
               BaseTestFunction("402000050009000020000000137700000000020307000300100500000050001000002600068040000"));

        }
        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual("618543792352179864794682135481956327267314589935827641876495213543261978129738456",
               BaseTestFunction("000043002050000000704600100080900000060000500905020001800000000000060070109700400"));

        }
        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual("376594281495821376812376459238749165169285743547163892924638517653417928781952634",
               BaseTestFunction("370590001005800000010306400208040065009000700540060802004608010000007900700052034"));

        }
        [TestMethod]
        public void TestMethod11()
        {
            Assert.AreEqual("543286917621973854798541623287134596314695782965827341876419235452368179139752468",
               BaseTestFunction("000000000000000000000000000000000000000000000905020001800000000000060070109700400"));

        }
        [TestMethod]
        public void TestMethod12()
        {
            Assert.AreEqual("2314142331424231",
               BaseTestFunction("0004100001000230"));

        }
        [TestMethod]
        public void TestMethod13()
        {
            Assert.AreEqual("1324243131424213",
               BaseTestFunction("1004003000000200"));

        }
        [TestMethod]
        public void TestMethod14()
        {
            Assert.AreEqual(";3<8716>:4=?95@26>714=?:@2958;3<?:4=295@3<8;16>75@29<8;3>716=?:4>416=?:2<95@;378:2=?95@<78;36>41@<958;37416>?:2=378;16>42=?:5@<971;36>4=9?:2@<854=6>?:2985@<371;29?:5@<81;37>4=6<85@;371=6>4:29?1637>4=?5:29<8;@=?>4:295;@<8716395:2@<8;63714=?>8;@<3716?>4=295:",
               BaseTestFunction("0300000>:40095@000704=00@0908030?04029500<8000>70@09000300160?:004100?:0<90@;370000?05@078006>01@0058000000>?000378006000=0050<070;0600=0?:200804=000:290500371;200000001;07>4=0000@;37100>400900007>40?0:09<000000000900@<001609502@08;03010=?080003700?04=090:"));

        }
        [TestMethod]
        public void TestMethod15()
        {
            Assert.AreEqual("7;@?><89:63=51429><8:63=2514@?7;=:632514;@?7<89>4251;@?7><8963=:;@?9<8=>634:1725><8=634:5172?9;@:6345172@?9;8=><2517@?9;<8=>34:6517;?9>@8=:<4263@?9>8=:<34267;51<8=:342617;59>@?634217;5?9>@=:<834257;@19><?:68=17;@9><?=:682534?9><=:684253;@178=:642537;@1><?9",
               BaseTestFunction("0;000000000=514200<8063=2014@?700060001400?008000050;007><8000=:0000080>000007200<00604:0172?0;006345002@?9;800<0000@?90<00>00000000090@0=0<0000@?9>800<04207;00080:300600050>@000421005?9>@00<0000570@19><?:600100@90<00:08253009><=:00000000008=:6420070@00009"));

        }
        [TestMethod]
        public void TestMethod16()
        {
            Assert.AreEqual("3681:9>@47=?;25<>@:947=?;25<8136=?47;25<8136:9>@5<;28136:9>@47=?@:9=75?423<;1>68?47523<;1>689=@:<;231>689=@:75?4681>9=@:75?423<;475<36;2>@81=?:9;236>@81=?:95<4781>@=?:95<4736;2:9=?5<4736;2>@812368@:1>?49=<;751>@:?49=<;7568239=?4<;756823@:1>75<;6823@:1>?49=",
               BaseTestFunction("3081000@07=?;05<00:907=?00008130000000008030:9>05<028036090@000?0:0=750000000>60000000<;0060900:0;2000680=@:7000000090@:750403<;075006;00000=0:00236>@8100:05<47800@0?090<070600:0=?0<4036;200802068@01>?490000000@0?090<00560239004007000230:0075<06020@:00?40="));

        }
        [TestMethod]
        public void TestMethod17()
        {
            Assert.AreEqual(">?<=;521693:7@847@84=>?<1;5293:63:697@84=>?<521;521;93:647@8>?<=47@8<=>?21;5693:93:647@8<=>?;521;521693:847@=>?<=>?<1;52:69347@8847@?<=>521;:693693:847@?<=>1;521;52:693@847<=>?<=>?21;53:69847@@847>?<=;5213:69:693@847>?<=21;521;53:697@84?<=>?<=>521;93:6@847",
               BaseTestFunction(">?<00520003:0@807080=0?01;0203:63:69708000?<020;521;00:04008>0<=07@80=0?20;56000900007@0<00?0500;000000:0470000<0>?01;52000307@884700<0>500000900900000@0<=010521050:600@007<0>0<00?20053:60000@080000<000210:00:00300070?0020;021003:697@84?000?<00500;00:0@000"));

        }
        [TestMethod]
        public void TestMethod18()
        {
            Assert.AreEqual("3E1?<7;865HFI=D9>C4G2B@:A:A2B@<3E1?57;86HFI=D4G9>C>C4G9@:A2B?<3E157;86=DHFIFI=DH9>C4GB@:A2?<3E18657;7;865HFI=DG9>C4B@:A2E1?<357;86DHFI=4G9>C2B@:A3E1?<<3E1?57;86DHFI=G9>C4A2B@:@:A2B?<3E1657;8DHFI=C4G9>9>C4GB@:A21?<3E657;8I=DHFHFI=DG9>C42B@:A1?<3E;8657G9>C42B@:AE1?<38657;FI=DHDHFI=4G9>CA2B@:E1?<37;865657;8=DHFIC4G9>A2B@:<3E1??<3E1657;8=DHFI4G9>C:A2B@B@:A21?<3E8657;=DHFI>C4G91?<3E8657;I=DHFC4G9>@:A2B2B@:AE1?<3;8657I=DHF9>C4G4G9>CA2B@:3E1?<;8657HFI=D=DHFIC4G9>:A2B@3E1?<57;868657;I=DHF>C4G9:A2B@?<3E1E1?<3;8657FI=DH>C4G9B@:A2A2B@:3E1?<7;865FI=DHG9>C4C4G9>:A2B@<3E1?7;865DHFI=I=DHF>C4G9@:A2B<3E1?657;8;8657FI=DH9>C4G@:A2B1?<3E",
               BaseTestFunction("0E0?0000050FI009>04G200:A0A0B@0001?57086H00=0409>00C00000020?000150006=0HF00I=009>00GB00000<0000007;0080000I=000>04B@:A0E10<350;0600F0=4000C2B00000000<000007;060HF00G90000000:0:02B0<300600000H0I000G0>9>040B@00000<00050;0I=000HF000G90002B@0010030;0607G9>C4000:A01?<3800700I0DH0HF0=0000C02000E10<000800650080DH00C0G00A0B@0<3E00?03E065708=D00000900002B0B00000?0000607;=00FI004091?03E80000I=D0000G00@:02B20@:000003006570=00F0004G000>CA000:001?<;86070F000=000IC0G000A0B@3000<50;0086070I0DHF000G0002000030100003;8000000D0>0409B0002000@:3E0?07;000FI00009>C000G00:00B000E1?000000000=0=0H0>C0090:00B<300?05700;0007F00DH000400:A0010030"));

        }
        [TestMethod]
        public void TestMethod19()
        {
            Assert.AreEqual("3@:;9?6EDIF=475B1>HA2CG<82CG<893@:;I?6ED5F=47>HAB1>HAB182CG<;93@:DI?6E=475F=475F1>HAB<82CG:;93@?6EDI6EDI?=475F1>HAB<82CG3@:;91>HAB<82CG:;93@EDI?6F=475F=475B1>HAG<82C@:;93I?6ED?6EDIF=475B1>HAG<82C93@:;93@:;I?6ED5F=47AB1>H82CG<82CG<;93@:DI?6E75F=41>HAB<82CG:;93@EDI?6475F=B1>HAB1>HAG<82C@:;936EDI?5F=475F=47AB1>HCG<823@:;9DI?6EI?6ED5F=47AB1>HCG<82;93@:;93@:DI?6E75F=4HAB1><82CG75F=4HAB1>2CG<893@:;EDI?6DI?6E75F=4HAB1>2CG<8:;93@:;93@EDI?6475F=>HAB1G<82CG<82C@:;936EDI?=475FAB1>HAB1>HCG<823@:;9?6EDI75F=4@:;936EDI?=475F1>HABCG<82CG<823@:;9?6EDIF=475HAB1>HAB1>2CG<893@:;I?6ED475F=475F=>HAB182CG<;93@:6EDI?EDI?6475F=>HAB182CG<@:;93",
               BaseTestFunction("30000060DIF=4000000020G002000093@00006E0000070HA00>H0B10200<0930:DI00E040000475000H0B080CG:;90006E0I60DI?=005010HAB002C00@0;910HA0002C00;90@E00000=405F000001>H0G082C00003I00000000I00000B00000<020930000300;0?6000F000AB00000C00800G0000@:D0?6E05F041000B<8200:0030EDI?6470F=0000A00>00G000C@:0006E0I00F0005F047AB100C0<80000;900?0EI00E000047A01>HC0<8009300;03@:0000E0500000B1>0800G00F040001>200<003@000D00000?6075F=0HA0000CG080;000:;9000DI06470F0000B1G<0200<80C0:;93600000405000100AB1000G<000@000?000I700=4@0000000I00475010000CG00000<0000000000D0F00700AB0>0AB000CG00900:0006E00000=4700=00AB000000;000:0000?E00?647500>00B082C0<@0003"));

        }
        [TestMethod]
        public void TestMethod20()
        {
            Assert.AreEqual("D:6E=4283@I1;5A>HGF7?9B<C<C?9B=D:6E283@41;5AI>HGF7F7>HGB<C?9D:6E=83@421;5AIAI1;5GF7>H<C?9B:6E=D83@42283@4AI1;57>HGF?9B<C6E=D:GF7>H9B<C?=D:6E283@4I1;5A5AI1;HGF7>B<C?9D:6E=283@44283@5AI1;F7>HGC?9B<:6E=D=D:6E@4283AI1;57>HGFC?9B<B<C?9E=D:64283@I1;5A7>HGFHGF7>?9B<CE=D:64283@AI1;5;5AI1>HGF79B<C?=D:6E4283@@4283;5AI1GF7>H<C?9BD:6E=E=D:63@4285AI1;F7>HG<C?9B9B<C?6E=D:@4283AI1;5F7>HG3@4281;5AIHGF7>B<C?9=D:6E6E=D:83@42;5AI1GF7>HB<C?9?9B<C:6E=D3@4285AI1;GF7>H>HGF7C?9B<6E=D:@42835AI1;1;5AI7>HGF?9B<CE=D:6@4283I1;5AF7>HGC?9B<6E=D:3@42883@42I1;5A>HGF79B<C?E=D:6:6E=D283@41;5AIHGF7>9B<C?C?9B<D:6E=83@42;5AI1HGF7>7>HGF<C?9B:6E=D3@428;5AI1",
               BaseTestFunction("D:6E=42800I00500HG00000<0<C09B=D000080@0100AI>0007F7>0000009D:00003002105A000100GF0>00C?000600D00002083040I0;50>0GF09B<000000007>H0B0C00006E200040000A5000;00F7>00C?0000E0280@4000305000000>H00?90006E000D00E0400300100000G00?90000C0000006420000000070HGF0000>?0B<0E=0:0028300I100;50I10HG070B0C0=0:00000000408305001007>0<0?90D06E=E00003@0200A00007>H0<C?9090<0?60=0:@0003A0100F700G0@400100A00GF000000900:6E00=008300200AI00F00HB0000?9B00:6000004200000;007>00HG00000B00E=D:0408350000100000000009000000:0@4083I0050000H0C09006E00:004080000000;0A>00F790<0?00D0606E=0000@01050I00F000B0C0C?000000E003@42;5A010007>70H000C?9B00E=00@000000I1"));

        }
        [TestMethod]
        public void TestMethod21()
        {
            Assert.AreEqual("<:;?97BA185I4E2=3C@FHD6>G87BA15I4E23C@F=D6>GH9<:;?25I4E3C@F=6>GHD<:;?9187BA=3C@F6>GHD:;?9<87BA1E25I4D6>GH:;?9<7BA1825I4EF=3C@3C@H=>G9D6;?1<:7BAE825I4F6>G9D;?1<:BAE875I4F2=3C@H:;?1<BAE87I4F253C@H=D6>G97BAE8I4F25C@H=36>G9D<:;?15I4F2C@H=3>G9D6:;?1<87BAEC@HD3G9<6>?18:;BAE275I4F=>G9<6?18:;AE27BI4F=53C@HD;?18:AE27B4F=5IC@HD36>G9<BAE274F=5I@HD3C>G9<6:;?18I4F=5@HD3CG9<6>;?18:7BAE24F=3IHD6C@9<:>G?187;BAE25@HD6C9<:>G187;?AE25BI4F=3G9<:>187;?E25BA4F=3IC@HD6?187;E25BAF=3I4@HD6C>G9<:AE25BF=3I4HD6C@G9<:>;?187F=3C4D6>@H<:;G9187B?AE25IHD6>@<:;G987B?1E25IA4F=3C9<:;G87B?125IAEF=3C4@HD6>187B?25IAE=3C4FHD6>@G9<:;E25IA=3C4FD6>@H9<:;G?187B",
               BaseTestFunction("<:;090BA000I0E203C0FHD0>G070000I0E03C@0=06>GH900;02504E30@F0600H0<00?0100BA0000F0>G0D00?9<870A0E05I406>00:;?007000020I00F=0C03C@00>G000;01<:00A0825I00000900?0<00AE070I0F2=00@00;010BA000I40050C00=D0>090BA0004020C@H036>G9000001500F200000>00D6:00008700E0@003G0<00?18:00AE07000F=0G900?10:;AE200000=000@HD;?18:00200400500@0036>G0<B0E204F05I@0000>G0<6:;018I000000D0009<6>000800BA024000I0000090:>G0180;0AE05@H060000>G087000E25B00F=000<000800?025B04003IC0H06?100;E25B00=304@HD00000<00E250F030000600G9<0>;01870=0C006>@H<:009180B0A005IH060@0:;0007B?0E05I04F00C9<:0080B002500E0=3C40H06>00700200AE=3000HD00@0000000000=0040D0>00900;G?1000"));

        }
        [TestMethod]
        public void TestMethod22()
        {
            Assert.AreEqual("265DEIA14C;98GB:H7@F3?=<>14CIAB;98G7@F:H<>3?=E265D98GB;H7@F:3?=<>5DE26A14CI@F:H7>3?=<E265DCIA14;98GB?=<>3DE265A14CIGB;987@F:HF:>7@3?=<D265IEBA14C98GH;=<D3?E265I14CBAH;98G@F:>765IE2A14CB98GH;>7@F:?=<D34CBA1;98GH@F:>7D3?=<265IE8GH;97@F:>?=<D3IE26514CBA<DE?=265IA4CB;1798GHF:>3@5IA2614CB;8GH793@F:>=<DE?CB;1498GH7F:>3@E?=<D65IA2GH798@F:>3=<DE?A265I4CB;1:>3@F?=<DE65IA2;14CB8GH79>3?F:=<DE25IA1694CB;GH7@8DE2=<65IA1CB;94@8GH7:>3?FIA1654CB;9GH7@8?F:>3<DE2=B;94C8GH7@:>3?F2=<DE5IA16H7@8GF:>3?<DE2=165IACB;947@FGH:>3?=DE26<45IA1B;98C3?=:><DE26IA1458CB;9H7@FGE26<D5IA14B;98CFGH7@>3?=:A145ICB;98H7@FG=:>3?DE26<;98CBGH7@F>3?=:6<DE2IA145",
               BaseTestFunction("005DEI0000;9800:070F00000000I0B098G0@F:H0>3?0E0600080B;000F03?0<>5DE20A100I00:0003?=00200000000090G0?=<00D0265A10C00B0900000HF0000000<0005IEBA04C9000;=003?0265I00C0A0098000:00000E2A04C098GH;00@F00=<0000BA0;080H@F0>7030=0200IE000;07@F:0?0<D3I006010CB00DE?0260I00C001090G0F:>0000A2004C000GH003@0:0=0D0?0000098GH0F0>3@E?=0065002G07980F:>3=<D0?A265000000:>00F?0000000A2;040B8G070>0?00=00E050016040B;G00@0D020<65I01CB094@00H7:>0?0IA1654C000G00@8?00000000=0094C8007@:00002=<DE0IA00H700G00>0?<DE0=100IAC0;900@FGH:00?=DE20000IA00;08C0?0:>000000A1408C0;0H7@00E00<D0IA14B;9000G07@030=00145I0B;9800@0G0000?0E00<0080BGH7@F000=:60DE000100"));

        }
        [TestMethod]
        public void TestMethod23()
        {
            Assert.AreEqual("7<=5AHBD29@GE:F86;34I?1>C29HBDGE:F@86;34I?1>C<=5A7F@GE:6;348I?1>C<=5A79HBD2486;3?1>CI<=5A79HBD2@GE:FCI?1>=5A7<9HBD2@GE:F86;348GE:F;34I6?1>C<=5A79HBD2@I6;341>C<?=5A79HBD2@GE:F8<?1>C5A79=HBD2@GE:F86;34I9=5A7BD2@HGE:F86;34I?1>C<@HBD2E:F8G6;34I?1>C<=5A79=1>C<A79H5BD2@GE:F86;34I?H5A79D2@GBE:F86;34I?1>C<=GBD2@:F86E;34I?1>C<=5A79H6E:F834I?;1>C<=5A79HBD2@G?;34I>C<=15A79HBD2@GE:F86134I?C<=5>A79HBD2@GE:F86;5>C<=79HBAD2@GE:F86;34I?1BA79H2@GED:F86;34I?1>C<=5ED2@GF86;:34I?1>C<=5A79HB;:F864I?13>C<=5A79HBD2@GE:2@GE86;3F4I?1>C<=5A79HBD3F86;I?1>4C<=5A79HBD2@GE:>4I?1<=5AC79HBD2@GE:F86;3AC<=59HBD72@GE:F86;34I?1>D79HB@GE:2F86;34I?1>C<=5A",
               BaseTestFunction("7<00AH0D0000E:F80;00I?1>0090BDG000@06;300?000<05070000:6;008I00>0<05A09HB0240603?0>00<=5000HB02@0E0FCI?0>05A009HBD20G00F80000800:F030I0?1>0<=5A790000006;041>C<000079H002@0E0080?100507900BD0@G0:006;04I000A7B0200GE0086;30I?10C<@H0D000F8G60340?10C<=5A79=0>0<00000000@000F80;34I0H5009D0@G000F86;300?000<=G0000:F86E000I?00C<00009H0000034I?00>C<=50700B02@00;300000=000700BD2@GE:F0603400C0=0>07000000G00086;0>C<=09H0AD200E0000;000?1B00000@GE0:086030I01>0000E02@GF06;0340?100<=5A0900;:00040?130C0=5000HB02@0000@G0860004I?10C000A790B03F8600?0>40<05079H0D20GE:04I00<00A0090B000GE0F0003A0005000D02@000F80030I010079HB0GE00080;30001000000"));

        }
        [TestMethod]
        public void TestMethod24()
        {
            Assert.AreEqual("BIFG1=?<>:649HD5C@78;A23EE;A23BIFG1<>:=?D649H85C@7@785C3E;A2IFG1B=?<>:9HD64649HDC@785E;A231BIFG>:=?<?<>:=D649H@785C23E;AFG1BI=?<>:HD649C@785A23E;IFG1B1BIFG:=?<>D649H85C@7E;A233E;A21BIFG?<>:=HD649785C@C@78523E;ABIFG1:=?<>49HD6D649H5C@783E;A2G1BIF<>:=?5C@78A23E;1BIFG>:=?<649HDHD64985C@723E;AFG1BI?<>:=:=?<>9HD645C@78;A23EBIFG1G1BIF>:=?<HD649785C@3E;A223E;AG1BIF=?<>:9HD64@785CFG1BI<>:=?9HD64@785C23E;AA23E;FG1BI:=?<>49HD6C@78585C@7;A23EG1BIF<>:=?D649H9HD64785C@A23E;IFG1B=?<>:>:=?<49HD685C@7E;A231BIFG785C@E;A23FG1BI?<>:=HD64949HD6@785C;A23EBIFG1:=?<><>:=?649HD785C@3E;A2G1BIFIFG1B?<>:=49HD6C@785A23E;;A23EIFG1B>:=?<649HD5C@78",
               BaseTestFunction("0IFG1=0<0:6490D50@780003EE0020B0F01000=0D049H050@0@000000;000FG00000009HD6004000C008000A23000F0>:=00000:=0009H0780023E0AF01BI=?<>0H0040C0080A230000010000FG:000>D0000000070;A20300021BIF0?<>0=H0600000000@080200;A0IFG00=?00000D60640H5C@0000;A0G0B0F<>0=?0C@78A23E0100FG>0=?0640H0HD6000500703E;00G00I0<>:000?<>9H0005C008;A03EB0001G10IF>:=0<0D049000C000;020000A010000?0>0000000785C001BI0>0=09HD60@705C20E;0A03E;FG10I0=0<009H000078580C@00A03EG10I0<>:=?D64000HD0000000A20000FG1B0?<>:0:0?0400D0000@7E000000IF0080C0E;0230G0BI?<>0=H000040006078500000EBI001:0?0>00000640HD085C030;A0G100F000100<>:=49000C@780000E;0A200I0G000:00<040HD0C@78"));

        }
        [TestMethod]
        public void TestMethod25()
        {
            Assert.AreEqual("?9C6:831<42IGEH>@75D=FA;B4831<EH2IGD>@75FA;B=6:?9CGEH2I75D>@=FA;B:?9C61<483@75D>;B=FA6:?9C<48312IGEHA;B=F9C6:?1<483IGEH2D>@757H2IG5D>@;FA9B=?8C6:<4E31;5D>@B=FA9:?8C64E31<IG7H29B=FAC6:?8<4E31G7H2I>@;5D8C6:?31<4EIG7H2@;5D>FA9B=E31<4H2IG7>@;5DA9B=F:?8C6BD>@;=FA9C?836:EH1<4G752IC=FA96:?834EH1<752IG@;BD>36:?81<4EHG752I;BD>@A9C=FH1<4E2IG75@;BD>9C=FA?836:52IG7D>@;BA9C=F836:?4EH1<1:?83<4EH275DIGB=>@;9C6FA2<4EHIG75D;B=>@C6FA9831:?DIG75>@;B=9C6FA31:?8EH2<4=>@;BFA9C6831:?H2<4E75DIG6FA9C:?831EH2<45DIG7;B=>@F@;B=A9C6:31<?82I4EH5D>G7:A9C6?831<H2I4ED>G75B=F@;<?8314EH2I5D>G7=F@;BC6:A9I4EH2G75D>B=F@;6:A9C31<?8>G75D@;B=FC6:A91<?83H2I4E",
               BaseTestFunction("?906:8300000GE0>@700=FA0B083100H0IGD>@70F000=0:?00GEH0I70D>@000;0:00C000080@05D>00=F00:?00<08312IG0000B=F900:01048000EH0D>@057020G00000F000=08C0:04E01;500000000000C64E31<I00H09B=0A06008<4030G002I00000006:031040I0002@050>FA000E0104020G7>@;5000B=0:00C0B0>@000A0C0030:0010007500C=0A9600804E010750IG0;00>00:000000HG002I;BD00A0C=0H1<40200750;00>9C00A0836050000D>0;0A0C0F0360?4E00<0008300EH270D0G0=>@0006F0200EHI075D;B=>@C0F00001:0D007500;B=006FA000?8E0004=0@0B0A9C0831:000<4000D0G00A0C00000000<050I0000=>@0@00000C6001<?80000H5D0070A00000000H200ED0G7000F@;<0031400000D0G700@;BC6:0000EH20050>B0F@06:A0001<08007500;0=0C6:001<08002I0E"));

        }
        [TestMethod]
        public void TestMethod26()
        {
            Assert.AreEqual("D34F2?AI96CG<B7=:;E18@>H5?AI96G<B7C;E1=:@>H5834F2DG<B7CE1=:;H58@>4F2D3AI96?E1=:;58@>H2D34FI96?A<B7CG58@>HD34F26?AI9B7CG<1=:;E3@>H5A4F2D?<I967CG1B=:;E8A4F2D<I96?G1B7C:;E8=@>H53<I96?1B7CGE8=:;>H53@4F2DA1B7CG8=:;E53@>HF2DA4I96?<8=:;E3@>H5DA4F296?<IB7CG1IF2DAB96?<1=7CG;E8@:>H534B96?<=7CG18@:;EH534>F2DAI=7CG1@:;E834>H52DAIF96?<B@:;E84>H53AIF2D6?<B97CG1=4>H53IF2DA<B96?CG1=7:;E8@>;E8@FH534I92DA?<B76CG1=:FH53492DAIB76?<G1=:C;E8@>92DAI76?<B=:CG1E8@>;H534F76?<B:CG1=@>;E8534FH2DAI9:CG1=>;E8@4FH53DAI926?<B7HE8@>2534F96DAI<B7C?G1=:;2534F6DAI97C?<B1=:;GE8@>H6DAI9C?<B7:;G1=8@>HE534F2C?<B7;G1=:>HE8@34F25DAI96;G1=:HE8@>F2534AI96D?<B7C",
               BaseTestFunction("D0402?AI00CG0070:;010@0H0?0I00G00700E1000>050000000000C00=:0H08@>40203A000?E1=:;580>02030F090?A<B0CG08@0HD340060009B0000100000@>H5A40200<I0000G10=:;E0A002D<096?01B0C:;0000>H50<09601B0CGE0=0;>05300000A1B7000000E00@00F2D04I00?000:000@>000A0F000?0I0700000000000?<1=7CG0E80000500006?<=00010@0;0H534>0200I070G00:;E834>050DAIF060<B0:0E80>H030I0206?0B07000=4>0500F00A0090?CG1=00008@>0E0@00500I900000000C01=0FH530000A0B06?<010:00E80000DAI000<B=00G1E0000H004F000<B0CG0=0>;E85300H2DA00:C010>;00@4F003DA0900?<B0H08@>2034096000<000?G00:;0530F6D0000C?0B0=:00E000H6DAI00?<B70;00080>0E534F000007000=0>008000000D0I96000000E00002000A090D?<B00"));

        }
        [TestMethod]
        public void TestMethod27()
        {
            Assert.AreEqual("F134?CE2<=H56>G9I@DA7B8:;E2<=C>GH56I@DA98:;7B4?F13GH56>A9I@D:;7B8F134?=CE2<9I@DAB8:;7134?FE2<=C6>GH58:;7B?F1342<=CEGH56>DA9I@I56>G9:@DA;7B81234?FCEH<=:@DA981;7B34?F2H<=CE>GI561;7B8F234?<=CEHI56>GA9:@D234?FEH<=C56>GI:@DA9B81;7H<=CEGI56>@DA9:1;7B8?F23437B812<4?F=CEH5@6>GI9:;DA<4?F2H5=CE6>GI@;DA9:8137B5=CEHI@6>GDA9:;37B81F2<4?@6>GI:;DA97B813<4?F2EH5=C;DA9:137B84?F2<5=CEHGI@6>D>GI@;7A9:B8134=?F2<H56CE7A9:;34B81?F2<=6CEH5I@D>G4B813<=?F2CEH56D>GI@:;7A9=?F2<56CEH>GI@D7A9:;134B86CEH5@D>GIA9:;74B8132<=?FCF2<=6>EH5GI@DAB9:;734?81>EH56DAGI@9:;7B?8134<=CF2AGI@D7B9:;8134?CF2<=56>EHB9:;74?813F2<=C>EH56@DAGI?8134=CF2<EH56>AGI@D;7B9:",
               BaseTestFunction("F100?0E2<=006>G0I@007B000E00=000056I0D0900000000130H00>A900D:;7B8F000?00E000I0DAB800703000E20=00>GH50:;0B?00342<=0000500D090@I00>0000DA;0080034000EH<=000A90100B04?020<=CE00I00000B802300<0C00I00>G00:0D234?00H00C560G000D0900100H00CEGI560@0A901;008?020430081000?0000H50000090000<0?F2H000E00GI0;DA0:0037B5000HI000GD000037B01F2000000GI0;DA97B010<40F2005=C;0A9:030B80?02<5=CEHG0@600>0I@;7A00B0104=000<0500E7000034B810F20=00E00000000B80000?F2CE050D>00@:07A000F0<50C0H>G00D0090;104B06C0H5@D00I09000000002<=?0CF00=60EH5G00DAB9:0700000>0056D00I00:;7008134<=C020GI@07000;8130?C00<=0600HB00;700800F200C>0H060D000?0034=000<0H50>0G00D00B0:"));

        }
        [TestMethod]
        public void TestMethod28()
        {
            Assert.AreEqual("E9AF8D3<5BH14I=2:?>;6@7CG6@7CG9AF8ED3<5B=H14I;2:?>>;2:?6@7CGE9AF85BD3<4I=H114I=H>;2:?G6@7CF8E9A3<5BDD3<5B14I=H?>;2:7CG6@9AF8EG6@7CE9AF8BD3<5I=H14>;2:??>;2:G6@7C8E9AF<5BD314I=HH14I=?>;2:CG6@7AF8E9D3<5BBD3<5H14I=:?>;2@7CG6E9AF88E9AFBD3<5=H14I;2:?>G6@7C=H14I:?>;27CG6@9AF8EBD3<55BD3<=H14I2:?>;6@7CG8E9AFF8E9A5BD3<I=H14>;2:?CG6@7CG6@78E9AF5BD3<4I=H1?>;2::?>;2CG6@7F8E9A3<5BDH14I=2:?>;7CG6@AF8E9D3<5B=H14II=H142:?>;@7CG6E9AF85BD3<<5BD3I=H14;2:?>G6@7CF8E9AAF8E9<5BD34I=H1?>;2:7CG6@7CG6@F8E9A<5BD314I=H:?>;2@7CG6AF8E93<5BDH14I=2:?>;;2:?>@7CG69AF8EBD3<5I=H144I=H1;2:?>6@7CG8E9AF<5BD33<5BD4I=H1>;2:?CG6@7AF8E99AF8E3<5BD14I=H:?>;2@7CG6",
               BaseTestFunction("E90F80305B0100=0:?>;6@7C00@70G0AF8E03<500H10I000000;00?0@00GE00F85BD00400H1040=H0000?06@0C080003<000D000014I=H?>;0:7C0600000E00@7CE0A0000305I=H14>00:0?002:G6@708E0A000B0304I00H140=?000:C06@0A08E003<0B003050100000>02@7C06090F80E0AF0D3<0001400200>06@70=0140:?>;20CG6@9A08EBD0<05B00<0H00I00?>06@7000E0A0F009A0B03<I=H100;20?C0607C06@00090F000004I=01?0;000?0020000008000000BD0100000?>;70G60AF8E903<5B=0140I0000200>0@7C0609AF85B00000B000=H0400:?006@7000E90008E000B0040=H0?00200CG0@00G00F009A<50D3140000000207C06000E93<0B0H04002:?>0;20?000C069AF0EB0000000104I0010000>600CG000AF000033050D40=010;000CG6@0A08009008E3<5B0000000?000@70G6"));

        }
        [TestMethod]
        public void TestMethod29()
        {
            Assert.AreEqual("I2:13D=<5B4>@897A6CHEG?F;?F;EG2:13I<5BD=@894>6CH7A7A6CH;EG?F3I2:1D=<5B4>@89@894>A6CH7G?F;E2:13I<5BD=BD=<5894>@CH7A6F;EG?13I2:3I2:1BD=<594>@8H7A6C;EG?FG?F;EI2:13=<5BD>@894A6CH7H7A6CF;EG?13I2:BD=<594>@8>@8947A6CHEG?F;I2:13=<5BD5BD=<@894>6CH7A?F;EG:13I213I2:5BD=<894>@CH7A6F;EG?EG?F;3I2:1D=<5B4>@897A6CHCH7A6?F;EG:13I25BD=<894>@4>@89H7A6C;EG?F3I2:1D=<5B<5BD=>@894A6CH7G?F;E2:13I94>@8CH7A6F;EG?13I2:BD=<5=<5BD4>@897A6CHEG?F;I2:13:13I2<5BD=@894>6CH7A?F;EG;EG?F13I2:BD=<594>@8H7A6C6CH7AG?F;E2:13I<5BD=@894>F;EG?:13I25BD=<894>@CH7A6A6CH7EG?F;I2:13=<5BD>@894894>@6CH7A?F;EG:13I25BD=<D=<5B94>@8H7A6C;EG?F3I2:12:13I=<5BD>@894A6CH7G?F;E",
               BaseTestFunction("02010D=<0B4>0890000HEG00;00;EG0010000BD=089000CH707000H;E0000I0:10=05040009@004>A60070?F;E2:00000B0=0D0<0890>@C0700F000?0002:300:1BD000940@807A00;0G?FG?F;0I00130<500>@800A0007H0060F;00013000BD=<594>08>@800006C0000F;I2:03=05B0500=<0004>600000F;EG:000003I2050D=<800>@00006F000?00?F0002:00=00B0>@80706C0C07A0?F0EG010025BD008940000@09H7000;E0?030001D=<00<0000>@804A0CH0G000E2:00004>@00H006F000?0000:B0000=05BD00@897A0C00G?F;0001301302<5B00@89406C070?F;00;EG0F03I0:0D=0090>@00006C0C000G?F;00:13I<5B0=00000F0E0?01002500=080400C07A006CH7000F002000=0500>@800004>@0000A0F;EG010000000<D0<5094>@0H7A0C;EG?03020100000=00BD00090A0CH0G?F0E"));

        }
        [TestMethod]
        public void TestMethod30()
        {
            Assert.AreEqual("HC<F4D:;?I6589=3>EB@172AG172AG<F4HC;?ID:6589=3>EB@>EB@3AG172HC<F4?ID:;589=6589=6B@3>E172AGHC<F4?ID:;?ID:;9=6583>EB@172AGHC<F43>EB@2AG174HC<F;?ID:6589=6589=EB@3>G172A4HC<F;?ID:;?ID:89=65@3>EBG172A4HC<F4HC<FID:;?=6589@3>EBG172AG172AC<F4H:;?ID=6589@3>EB:;?ID589=6B@3>EAG172F4HC<F4HC<?ID:;9=658B@3>EAG172AG172HC<F4D:;?I9=658B@3>E@3>EB72AG1F4HC<:;?ID=6589=6589>EB@3AG172F4HC<:;?ID2AG174HC<FID:;?89=65EB@3>B@3>E172AG<F4HCD:;?I9=6589=6583>EB@2AG17<F4HCD:;?ID:;?I6589=EB@3>2AG17<F4HC<F4HC;?ID:89=65EB@3>2AG1772AG1F4HC<?ID:;589=6>EB@3EB@3>G172AC<F4HID:;?89=6589=65@3>EB72AG1C<F4HID:;?ID:;?=6589>EB@372AG1C<F4HC<F4H:;?ID589=6>EB@372AG1",
               BaseTestFunction("H0<F4D:;0065800300B00020G07000<F4HC;0I006500=0>00@>0000AG1720C0F0?0D:000906580=000000100A0H00F4000:00I0009=6500>0B0000AGHC<F0300B00AG104HC<0;?0D00500060090EB@3>0102040C<00?0D0000D:80=05@30EB010200HC<F40C00ID:;00608003>0001700G17000<00H0;?0D=6580@0>00:;?ID080=600000000000000<040000ID:09=600B03>EAG10200102H00F0D:;0I9=0580030E03>E0000010000000?ID=0500=6089>E0@0A0170F40C0:;0I000G100HC<FID0;?09000EB030B00000020G0F00C000?09=6589=058300B@00G170F4HC00;000:;?065890E0@0>2A017<F4H0<00H0;?0D:89=600B@000000070AG0F4H000I0:;00900>0B@0EB03>G000AC<04HID00?0906580=05@30E0000000<0400D00?I00;?0008900B0002000C<F00C<00H0;?I0509=000003700G1"));

        }
        //Exceptions
        [TestMethod]
        public void TestMethod31()
        {
           Assert.ThrowsException<CharNotValidException>(() => BaseTestFunction("A02000050009000020000000137700000000020307000300100500000050001000002600068040000"));
        }
        [TestMethod]
        public void TestMethod32()
        {
            Assert.ThrowsException<DimensionsOfBoardNotValidException>(() => BaseTestFunction("12342341221434321"));
        }
        [TestMethod]
        public void TestMethod33()
        {
            Assert.ThrowsException<GridNotValidException>(() => BaseTestFunction("HHHHHH:;0065800300B00020G07000<F4HC;0I006500=0>00@>0000AG1720C0F0?0D:000906580=000000100A0H00F4000:00I0009=6500>0B0000AGHC<F0300B00AG104HC<0;?0D00500060090EB@3>0102040C<00?0D0000D:80=05@30EB010200HC<F40C00ID:;00608003>0001700G17000<00H0;?0D=6580@0>00:;?ID080=600000000000000<040000ID:09=600B03>EAG10200102H00F0D:;0I9=0580030E03>E0000010000000?ID=0500=6089>E0@0A0170F40C0:;0I000G100HC<FID0;?09000EB030B00000020G0F00C000?09=6589=058300B@00G170F4HC00;000:;?065890E0@0>2A017<F4H0<00H0;?0D:89=600B@000000070AG0F4H000I0:;00900>0B@0EB03>G000AC<04HID00?0906580=05@30E0000000<0400D00?I00;?0008900B0002000C<F00C<00H0;?I0509=000003700G1"));
        }
        [TestMethod]
        public void TestMethod34()
        {
            Assert.ThrowsException<GridUnsolveableException>(() => BaseTestFunction("200900000000000060000001000502600407000004100000098023000003080005010000007000000"));

        }
        [TestMethod]
        public void TestMethod35()
        {
            Assert.ThrowsException<CharNotValidException>(() => BaseTestFunction("Z90F80305B0100=0:?>;6@7C00@70G0AF8E03<500H10I000000;00?0@00GE00F85BD00400H1040=H0000?06@0C080003<000D000014I=H?>;0:7C0600000E00@7CE0A0000305I=H14>00:0?002:G6@708E0A000B0304I00H140=?000:C06@0A08E003<0B003050100000>02@7C06090F80E0AF0D3<0001400200>06@70=0140:?>;20CG6@9A08EBD0<05B00<0H00I00?>06@7000E0A0F009A0B03<I=H100;20?C0607C06@00090F000004I=01?0;000?0020000008000000BD0100000?>;70G60AF8E903<5B=0140I0000200>0@7C0609AF85B00000B000=H0400:?006@7000E90008E000B0040=H0?00200CG0@00G00F009A<50D3140000000207C06000E93<0B0H04002:?>0;20?000C069AF0EB0000000104I0010000>600CG000AF000033050D40=010;000CG6@0A08009008E3<5B0000000?000@70G6"));
        }
        [TestMethod]
        public void TestMethod36()
        {
            Assert.ThrowsException<DimensionsOfBoardNotValidException>(() => BaseTestFunction("0300000>:40095@000704=00@0908030?04029500<8000>70@09000300160?:004100?:0<90@;370000?05@078006>01@0058000000>?000378006000=0050<070;0600=0?:200804=000:290500371;200000001;07>4=0000@;37100>400900007>40?0:09<000000000900@<001609502@08;03010=?080003700?04=090:00999"));
        }
        [TestMethod]
        public void TestMethod37()
        {
            Assert.ThrowsException<GridNotValidException>(() => BaseTestFunction("FFFF?0E2<=006>G0I@007B000E00=000056I0D0900000000130H00>A900D:;7B8F000?00E000I0DAB800703000E20=00>GH50:;0B?00342<=0000500D090@I00>0000DA;0080034000EH<=000A90100B04?020<=CE00I00000B802300<0C00I00>G00:0D234?00H00C560G000D0900100H00CEGI560@0A901;008?020430081000?0000H50000090000<0?F2H000E00GI0;DA0:0037B5000HI000GD000037B01F2000000GI0;DA97B010<40F2005=C;0A9:030B80?02<5=CEHG0@600>0I@;7A00B0104=000<0500E7000034B810F20=00E00000000B80000?F2CE050D>00@:07A000F0<50C0H>G00D0090;104B06C0H5@D00I09000000002<=?0CF00=60EH5G00DAB9:0700000>0056D00I00:;7008134<=C020GI@07000;8130?C00<=0600HB00;700800F200C>0H060D000?0034=000<0H50>0G00D00B0:"));
        }
        [TestMethod]
        public void TestMethod38()
        {
            Assert.ThrowsException<GridUnsolveableException>(() => BaseTestFunction("123000000000040000000000004000000000000000000000000000000000000000000000000000000"));

        }

    }
}