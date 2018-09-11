using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    static class Data
    {
        public static Dictionary<Tournament, Dictionary<bool, Dictionary<string, Dictionary<string, int>>>> All;
        public static Dictionary<string, string> ShortNames = @"
Aaron Krickstein=Krickstein
Adrian Voinea=Voinea
Adriano Panatta=Panatta
Ágnes Szávay=Szávay
Agnieszka Radwańska=Radwańska
Ai Sugiyama=Sugiyama
Albert Costa=Costa
Albert Ramos-Viñolas=Ramos-Viñolas
Alberto Berasategui=Berasategui
Alberto Mancini=Mancini
Àlex Corretja=Corretja
Alex Metreveli=Metreveli
Alex Rădulescu=Rădulescu
Alexander Popp=Popp
Alexander Volkov=Volkov
Alexander Zverev=Zverev
Alexandra Stevenson=Stevenson
Alison Van Uytvanck=Uytvanck
Amanda Coetzer=Coetzer
Amélie Mauresmo=Mauresmo
Amy Frazier=Frazier
Ana Ivanovic=Ivanovic
Ana Konjuh=Konjuh
Anastasia Myskina=Myskina
Anastasija Sevastova=Sevastova
Anders Järryd=Järryd
Andre Agassi=Agassi
André Sá=Sá
Andrea Jaeger=Jaeger
Andrea Petkovic=Petkovic
Andrei Cherkasov=Cherkasov
Andrei Chesnokov=Chesnokov
Andrei Medvedev=Medvedev
Andrei Pavel=Pavel
Andrés Gimeno=Gimeno
Andrés Gómez=Gómez
Andrew Pattison=Pattison
Andrey Rublev=Rublev
Andriy Medvedev=Medvedev
Andy Murray=Murray
Andy Roddick=Roddick
Angelique Kerber=Kerber
Anke Huber=Huber
Ann Haydon-Jones=Haydon-Jones
Ann Jones=Jones
Anna Chakvetadze=Chakvetadze
Anna Kournikova=Kournikova
Anna-Lena Grönefeld=Grönefeld
Anne Smith=Smith
Annette Van Zyl=Van Zyl
Arantxa Sánchez=Sánchez
Arnaud Clément=Clément
Arthur Ashe=Ashe
Balázs Taróczy=Taróczy
Barbara Gerken=Gerken
Barbara Hallquist=Hallquist
Barbara Potter=Potter
Barbara Schett=Schett
Barbara Schwartz=Schwartz
Barbora Strýcová=Strýcová
Belinda Bencic=Bencic
Bernard Tomic=Tomic
Bernd Karbacher=Karbacher
Bettina Bunge=Bunge
Bettina Fulco=Fulco
Betty Stöve=Stöve
Bill Scanlon=Scanlon
Billie Jean King=King
Billy Martin=Martin
Björn Borg=Borg
Bob Carmichael=Carmichael
Bonnie Gadusek=Gadusek
Boris Becker=Becker
Boro Jovanović=Jovanović
Brad Gilbert=Gilbert
Brad Pearce=Pearce
Brian Fairlie=Fairlie
Brian Gottfried=Gottfried
Brian Teacher=Teacher
Brigitte Simon=Simon
Bruce Manson=Manson
Butch Buchholz=Buchholz
Butch Walts=Walts
Byron Bertram=Bertram
Byron Black=Black
Camila Giorgi=Giorgi
Camille Benjamin=Benjamin
Carina Karlsson=Karlsson
Carla Suárez Navarro=Suárez
Carling Bassett=Bassett
Carlos Moyà=Moyà
Caroline Garcia=Garcia
Caroline Wozniacki=Wozniacki
Catarina Lindqvist=Lindqvist
Cédric Pioline=Pioline
Chanda Rubin=Rubin
Charlie Pasarell=Pasarell
Chris Evert=Evert
Chris Lewis=Lewis
Christian Bergström=Bergström
Cici Martinez=Martinez
Clarisa Fernández=Fernández
Clark Graebner=Graebner
Claudia Kohde-Kilsch=Kohde-Kilsch
Cliff Drysdale=Drysdale
Cliff Richey=Richey
CoCo Vandeweghe=Vandeweghe
Colin Dibley=Dibley
Conchita Martínez=Martínez
Corinne Molesworth=Molesworth
Corrado Barazzutti=Barazzutti
Dája Bedáňová=Bedáňová
Dan Goldie=Goldie
Daniela Hantuchová=Hantuchová
Daria Kasatkina=Kasatkina
Darren Cahill=Cahill
David Ferrer=Ferrer
David Goffin=Goffin
David Nalbandian=Nalbandian
David Wheaton=Wheaton
Davide Sanguinetti=Sanguinetti
Denisa Chládková=Chládková
Dennis Ralston=Ralston
Derrick Rostagno=Rostagno
Dianne Fromholtz=Fromholtz
Dick Stockton=Stockton
Diego Schwartzman=Schwartzman
Dinara Safina=Safina
Dominic Thiem=Thiem
Dominik Hrbatý=Hrbatý
Dominika Cibulková=Cibulková
Donna Ganz=Ganz
Earl Butch Buchholz=Buchholz
Eddie Dibbs=Dibbs
Ekaterina Makarova=Makarova
Elena Bovina=Bovina
Elena Dementieva=Dementieva
Elena Likhovtseva=Likhovtseva
Elena Subirats=Subirats
Elena Vesnina=Vesnina
Elina Svitolina=Svitolina
Eliot Teltscher=Teltscher
Emilio Sánchez=Sánchez
Ernests Gulbis=Gulbis
Eugenie Bouchard=Bouchard
Éva Szabó=Szabó
Evonne Cawley=Cawley
Evonne Goolagong=Goolagong
Fabio Fognini=Fognini
Feliciano López=López
Félix Mantilla Botella=Mantilla
Fernando González=González
Fernando Meligeni=Meligeni
Fernando Verdasco=Verdasco
Filip Dewulf=Dewulf
Fiorella Bonicelli=Bonicelli
Flavia Pennetta=Pennetta
Florența Mihai=Mihai
Florian Mayer=Mayer
Francesca Schiavone=Schiavone
Franco Davín=Davín
Franco Squillari=Squillari
François Jauffret=Jauffret
Françoise Dürr=Dürr
Frank Froehling=Froehling
Fred Stolle=Stolle
Frew McMillan=McMillan
Gabriela Sabatini=Sabatini
Gaël Monfils=Monfils
Gail Chanfreau=Chanfreau
Galo Blanco=Blanco
Garbiñe Muguruza=Muguruza
Gastón Gaudio=Gaudio
Gene Mayer=Mayer
Georges Goven=Goven
Gigi Fernández=Fernández
Gilles Müller=Müller
Gilles Simon=Simon
Goran Ivanišević=Ivanišević
Goran Prpić=Prpić
Greer Stevens=Stevens
Greg Rusedski=Rusedski
Gretchen Rush=Rush
Grigor Dimitrov=Dimitrov
Guillermo Cañas=Cañas
Guillermo Coria=Coria
Guillermo Pérez Roldán=Pérez Roldán
Guillermo Vilas=Vilas
Gustavo Kuerten=Kuerten
Guy Forget=Forget
Hana Mandlíková=Mandlíková
Hans Gildemeister=Gildemeister
Harold Solomon=Solomon
Heinz Günthardt=Günthardt
Helen Gourlay=Gourlay
Helen Kelesi=Kelesi
Helena Suková=Suková
Helga Masthoff=Masthoff
Helga Niessen=Niessen
Hendrik Dreekmann=Dreekmann
Henri Leconte=Leconte
Henrik Sundström=Sundström
Hicham Arazi=Arazi
Igor Andreev=Andreev
Ilie Năstase=Năstase
Inés Gorrochategui=Gorrochategui
Ion Țiriac=Țiriac
Irina Spîrlea=Spîrlea
Ismail El Shafei=Shafei
István Gulyás=Gulyás
Iva Majoli=Majoli
Ivan Lendl=Lendl
Ivan Ljubičić=Ljubičić
Ivanna Madruga=Madruga
Ivo Karlović=Karlović
Jacco Eltingh=Eltingh
Jaime Fillol=Fillol
Jaime Yzaga=Yzaga
Jakob Hlasek=Hlasek
James Blake=Blake
Jan Kodeš=Kodeš
Jan Siemerink=Siemerink
Jana Novotná=Novotná
Janet Newberry=Newberry
Janko Tipsarević=Tipsarević
Jan-Michael Gambill=Gambill
Jarkko Nieminen=Nieminen
Jason Stoltenberg=Stoltenberg
Javier Sánchez=Sánchez
Jay Berger=Berger
Jelena Dokic=Dokic
Jelena Dokić=Dokić
Jelena Janković=Janković
Jeļena Ostapenko=Ostapenko
Jennifer Capriati=Capriati
Jennifer Mundel=Mundel
Jerzy Janowicz=Janowicz
Jim Courier=Courier
Jimmy Arias=Arias
Jimmy Connors=Connors
Jo Durie=Durie
Joachim Johansson=Johansson
Joakim Nyström=Nyström
JoAnne Russell=Russell
Johan Kriek=Kriek
Johanna Konta=Konta
John Andrews=Andrews
John Isner=Isner
John Lloyd=Lloyd
John McEnroe=McEnroe
John Millman=Millman
John Newcombe=Newcombe
John Sadri=Sadri
Jonas Björkman=Björkman
Jonas Svensson=Svensson
José Higueras=Higueras
José Luis Clerc=Clerc
Jo-Wilfried Tsonga=Tsonga
Joyce Williams=Williams
Juan Carlos Ferrero=Ferrero
Juan Ignacio Chela=Chela
Juan Martín del Potro=del Potro
Judith Wiesner=Wiesner
Judy Tegart=Tegart
Julia Görges=Görges
Julie Halard=Halard
Julie Heldman=Heldman
Julien Benneteau=Benneteau
Jürgen Fassbender=Fassbender
Jürgen Melzer=Melzer
Justine Henin=Henin
Kaia Kanepi=Kanepi
Karel Nováček=Nováček
Karen Krantzcke=Krantzcke
Karina Habšudová=Habšudová
Karol Kučera=Kučera
Karolína Plíšková=Plíšková
Karolina Šprem=Šprem
Katerina Maleeva=Maleeva
Kateryna Bondarenko=Bondarenko
Kathy Horvath=Horvath
Kathy Jordan=Jordan
Kathy Kuykendall=Kuykendall
Kathy May=May
Kathy Rinaldi=Rinaldi
Katja Ebbinghaus=Ebbinghaus
Kazuko Sawamatsu=Sawamatsu
Kei Nishikori=Nishikori
Ken Rosewall=Rosewall
Kerry Reid=Reid
Kevin Anderson=Anderson
Kevin Curren=Curren
Kiki Bertens=Bertens
Kim Clijsters=Clijsters
Kim Warwick=Warwick
Kimiko Date=Date
Kirsten Flipkens=Flipkens
Kristina Mladenovic=Mladenovic
Larisa Neiland=Neiland
Larisa Savchenko=Savchenko
Laura Arraya=Arraya
Laura duPont=Laura duPont
Laura Golarsa=Golarsa
Leila Meskhi=Meskhi
Lesia Tsurenko=Tsurenko
Lesley Bowrey=Bowrey
Lesley Hunt=Hunt
Lesley Turner Bowrey=Bowrey
Li Na=Li
Linda Tuero=Tuero
Linda Wild=Wild
Lindsay Davenport=Davenport
Linky Boshoff=Boshoff
Lisa Bonder=Bonder
Lisa Raymond=Raymond
Lleyton Hewitt=Hewitt
Lori McNeil=McNeil
Lu Yen-hsun=Lu
Lucas Pouille=Pouille
Lucia Romanov=Romanov
Lucie Šafářová=Šafářová
Łukasz Kubot=Kubot
Madison Keys=Keys
Magdalena Maleeva=Maleeva
Magnus Larsson=Larsson
Magnus Norman=Norman
Magüi Serna=Serna
MaliVai Washington=Washington
Manon Bollegraf=Bollegraf
Manuel Orantes=Orantes
Manuela Maleeva=Maleeva
Marat Safin=Safin
Marc Rosset=Rosset
Marcelo Filippini=Filippini
Marcelo Ríos=Ríos
Marco Cecchinato=Cecchinato
Marcos Baghdatis=Baghdatis
Mardy Fish=Fish
Margaret Court=Court
Maria Bueno=Bueno
Maria Kirilenko=Kirilenko
Maria Sharapova=Sharapova
Mariano Puerta=Puerta
Mariano Zabaleta=Zabaleta
Marie Pinterova=Pinterova
Marijke Schaar=Schaar
Marin Čilić=Čilić
Mario Ančić=Ančić
Marion Bartoli=Bartoli
Marise Kruger=Kruger
Mark Dickson=Dickson
Mark Edmondson=Edmondson
Mark Philippoussis=Philippoussis
Marta Marrero=Marrero
Martín Jaite=Jaite
Martin Mulligan=Mulligan
Martin Verkerk=Verkerk
Martina Hingis=Hingis
Martina Navratilova=Navratilova
Marty Riessen=Riessen
Mary Joe Fernández=Fernández
Mary Pierce=Pierce
Maryna Godwin=Godwin
Mats Wilander=Wilander
Max Mirnyi=Mirnyi
Mel Purcell=Purcell
Melanie Oudin=Oudin
Melissa Brown=Brown
Meredith McGrath=McGrath
Michael Chang=Chang
Michael Stich=Stich
Michaëlla Krajicek=Krajicek
Mikael Pernfors=Pernfors
Mikhail Youzhny=Youzhny
Milan Šrejber=Šrejber
Milos Raonic=Raonic
Miloslav Mečíř=Mečíř
Mima Jaušovec=Jaušovec
Mirjana Lučić-Baroni=Lučić-Baroni
Miroslava Bendlova=Bendlova
Miroslava Holubova=Holubova
Molly Van Nostrand=Van Nostrand
Monica Seles=Seles
Nadia Petrova=Petrova
Nancy Richey=Richey
Nancy Richey Gunter=Gunter
Naomi Osaka=Osaka
Natasha Chmyreva=Chmyreva
Natasha Zvereva=Zvereva
Nathalie Tauziat=Tauziat
Nick Kyrgios=Kyrgios
Nicklas Kulti=Kulti
Nicolás Almagro=Almagro
Nicolas Escudé=Escudé
Nicolas Kiefer=Kiefer
Nicolás Lapentti=Lapentti
Nicole Provis=Provis
Nicole Vaidišová=Vaidišová
Nikola Pilić=Pilić
Nikolay Davydenko=Davydenko
Novak Djokovic=Djokovic
Odile de Roubin=de Roubin
Olga Morozova=Morozova
Onny Parun=Parun
Pablo Carreño Busta=Carreño Busta
Pam Shriver=Shriver
Pam Teeguarden=Teeguarden
Pancho Gonzales=Gonzales
Paola Suárez=Suárez
Paolo Bertolucci=Bertolucci
Pascale Paradis=Paradis
Pat Cash=Cash
Pat Dupre=Dupre
Pat DuPré=DuPré
Pat Rafter=Rafter
Patricia Hy=Hy
Patricio Cornejo=Cornejo
Patrick McEnroe=McEnroe
Patrick Proisy=Proisy
Patrick Rafter=Rafter
Patrik Kühnen=Kühnen
Patti Hogan=Hogan
Patty Schnyder=Schnyder
Paul Annacone=Annacone
Paul Chamberlin=Chamberlin
Paul Haarhuis=Haarhuis
Peaches Bartkowicz=Bartkowicz
Peng Shuai=Shuai
Pete Sampras=Sampras
Peter Fleming=Fleming
Peter McNamara=McNamara
Petr Korda=Korda
Petra Kvitová=Kvitová
Petra Mandula=Mandula
Petra Ritter=Ritter
Phil Dent=Dent
Philipp Kohlschreiber=Kohlschreiber
Radek Štěpánek=Štěpánek
Rafael Nadal=Nadal
Raffaella Reggi=Reggi
Rainer Schüttler=Schüttler
Ramesh Krishnan=Krishnan
Raquel Giscafré=Giscafré
Raúl Ramírez=Ramírez
Raymond Moore=Moore
Regina Maršíková=Maršíková
Renáta Tomanová=Tomanová
Renzo Furlan=Furlan
Ricardo Acuña=Acuña
Richard Gasquet=Gasquet
Richard Krajicek=Krajicek
Robby Ginepri=Ginepri
Robert Lutz=Lutz
Roberta Vinci=Vinci
Robin Söderling=Söderling
Rod Frawley=Frawley
Rod Laver=Laver
Rodney Harmon=Harmon
Roger Federer=Federer
Roger Taylor=Taylor
Ronald Agénor=Agénor
Rosalyn Fairbank=Fairbank
Roscoe Tanner=Tanner
Rosemary Casals=Casals
Roy Emerson=Emerson
Ruta Gerulaitis=Gerulaitis
Ruxandra Dragomir=Dragomir
Sabine Hack=Hack
Sabine Lisicki=Lisicki
Sam Querrey=Querrey
Samantha Stosur=Stosur
Sandra Cecchini=Cecchini
Sandrine Testud=Testud
Sandy Mayer=Mayer
Sara Errani=Errani
Sébastien Grosjean=Grosjean
Serena Williams=Williams
Sergi Bruguera=Bruguera
Sesil Karatantcheva=Karatantcheva
Séverine Beltrame=Beltrame
Shahar Pe’er=Shahar Pe’er
Shelby Rogers=Rogers
Shinobu Asagoe=Asagoe
Shuzo Matsuoka=Matsuoka
Silvia Farina Elia=Elia
Simona Halep=Halep
Sjeng Schalken=Schalken
Slava Doseděl=Doseděl
Sloane Stephens=Stephens
Slobodan Živojinović=Živojinović
Sorana Cîrstea=Cîrstea
Stan Smith=Smith
Stan Wawrinka=Wawrinka
Stanislas Wawrinka=Wawrinka
Stefan Edberg=Edberg
Steffi Graf=Graf
Sue Barker=Barker
Svetlana Kuznetsova=Kuznetsova
Sybille Bammer=Bammer
Sylvia Hanika=Hanika
Sylvia Plischke=Plischke
Tamarine Tanasugarn=Tanasugarn
Tamira Paszek=Paszek
Tatiana Golovin=Golovin
Terry Phelps=Phelps
Thierry Champion=Champion
Thomas Enqvist=Enqvist
Thomas Johansson=Johansson
Thomas Muster=Muster
Thomaz Koch=Koch
Tim Gullikson=Gullikson
Tim Henman=Henman
Tim Mayotte=Mayotte
Tim Wilkison=Wilkison
Timea Bacsinszky=Bacsinszky
Todd Martin=Martin
Todd Woodbridge=Woodbridge
Tom Gorman=Gorman
Tom Gullikson=Gullikson
Tom Okker=Okker
Tomáš Berdych=Berdych
Tomáš Šmíd=Šmíd
Tommy Haas=Haas
Tommy Robredo=Robredo
Tony Roche=Roche
Tracy Austin=Austin
Tsvetana Pironkova=Pironkova
Vasek Pospisil=Pospisil
Venus Williams=Williams
Vera Zvonareva=Zvonareva
Victor Hănescu=Hănescu
Víctor Pecci=Pecci
Victoria Azarenka=Azarenka
Vijay Amritraj=Amritraj
Virginia Ruano Pascual=Ruano Pascual
Virginia Ruzici=Ruzici
Virginia Wade=Wade
Vitas Gerulaitis=Gerulaitis
Vladimir Voltchkov=Voltchkov
Vlasta Vopičková=Vopičková
Wally Masur=Masur
Wayne Ferreira=Ferreira
Wendy Turnbull=Turnbull
Winnie Shaw=Shaw
Wojciech Fibak=Fibak
Xavier Malisse=Malisse
Yanina Wickmayer=Wickmayer
Yannick Noah=Noah
Yaroslava Shvedova=Shvedova
Yayuk Basuki=Basuki
Yevgeny Kafelnikov=Kafelnikov
Younes El Aynaoui=El Aynaoui
Yulia Putintseva=Putintseva
Yvonne Vermaak=Vermaak
Željko Franulović=Franulović
Zenda Liess=Liess
Zheng Jie=Zheng
Zina Garrison=Garrison"
            .Trim()
            .Replace("\r", "")
            .Split('\n')
            .Select(line => line.Split('='))
            .ToDictionary(arr => arr[0], arr => arr[1]);

        static Data()
        {
            All = new Dictionary<Tournament, Dictionary<bool, Dictionary<string, Dictionary<string, int>>>>();
            All[Tournament.FrenchOpenRolandGarros] = new Dictionary<bool, Dictionary<string, Dictionary<string, int>>> { { true, frenchOpenMens() }, { false, frenchOpenWomens() } };
            All[Tournament.USOpenFlushingMeadows] = new Dictionary<bool, Dictionary<string, Dictionary<string, int>>> { { true, usOpenMens() }, { false, usOpenWomens() } };
            All[Tournament.Wimbledon] = new Dictionary<bool, Dictionary<string, Dictionary<string, int>>> { { true, wimbledonMens() }, { false, wimbledonWomens() } };
        }

        // Start auto-generated
        
        static Dictionary<string, Dictionary<string, int>> wimbledonMens()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "Rod Laver", new Dictionary<string, int> { { "Dennis Ralston", 1 }, { "Arthur Ashe", 2 }, { "Tony Roche", 1 }, { "Cliff Drysdale", 1 }, { "John Newcombe", 1 } } },
                { "Arthur Ashe", new Dictionary<string, int> { { "Tom Okker", 1 }, { "Robert Lutz", 1 }, { "Björn Borg", 1 }, { "Tony Roche", 1 }, { "Jimmy Connors", 1 } } },
                { "Clark Graebner", new Dictionary<string, int> { { "Raymond Moore", 1 } } },
                { "Tony Roche", new Dictionary<string, int> { { "Butch Buchholz", 1 }, { "Clark Graebner", 2 }, { "Tom Okker", 1 } } },
                { "John Newcombe", new Dictionary<string, int> { { "Tom Okker", 1 }, { "Tony Roche", 1 }, { "Roy Emerson", 1 }, { "Andrés Gimeno", 1 }, { "Ken Rosewall", 2 }, { "Colin Dibley", 1 }, { "Stan Smith", 1 } } },
                { "Roger Taylor", new Dictionary<string, int> { { "Clark Graebner", 1 }, { "Björn Borg", 1 } } },
                { "Ken Rosewall", new Dictionary<string, int> { { "Tony Roche", 1 }, { "Roger Taylor", 1 }, { "Cliff Richey", 1 }, { "John Newcombe", 1 }, { "Stan Smith", 1 } } },
                { "Andrés Gimeno", new Dictionary<string, int> { { "Bob Carmichael", 1 } } },
                { "Tom Gorman", new Dictionary<string, int> { { "Rod Laver", 1 } } },
                { "Stan Smith", new Dictionary<string, int> { { "Onny Parun", 1 }, { "Tom Gorman", 1 }, { "Alex Metreveli", 1 }, { "Jan Kodeš", 1 }, { "Ilie Năstase", 1 }, { "Ismail El Shafei", 1 } } },
                { "Jan Kodeš", new Dictionary<string, int> { { "Onny Parun", 1 }, { "Vijay Amritraj", 1 }, { "Roger Taylor", 1 }, { "Alex Metreveli", 1 } } },
                { "Manuel Orantes", new Dictionary<string, int> { { "Colin Dibley", 1 } } },
                { "Ilie Năstase", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Manuel Orantes", 1 }, { "Charlie Pasarell", 1 }, { "Raúl Ramírez", 1 } } },
                { "Sandy Mayer", new Dictionary<string, int> { { "Jürgen Fassbender", 1 } } },
                { "Alex Metreveli", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Sandy Mayer", 1 } } },
                { "Jimmy Connors", new Dictionary<string, int> { { "Jan Kodeš", 1 }, { "Dick Stockton", 1 }, { "Ken Rosewall", 1 }, { "Raúl Ramírez", 2 }, { "Roscoe Tanner", 2 }, { "Byron Bertram", 1 }, { "John McEnroe", 2 }, { "Vitas Gerulaitis", 1 }, { "Bill Scanlon", 1 }, { "Vijay Amritraj", 1 }, { "Gene Mayer", 1 }, { "Mark Edmondson", 1 }, { "Paul Annacone", 1 }, { "Ivan Lendl", 1 }, { "Ricardo Acuña", 1 }, { "Slobodan Živojinović", 1 } } },
                { "Dick Stockton", new Dictionary<string, int> { { "Alex Metreveli", 1 } } },
                { "Roscoe Tanner", new Dictionary<string, int> { { "Guillermo Vilas", 1 }, { "Jimmy Connors", 1 }, { "Tim Gullikson", 1 }, { "Pat DuPré", 1 } } },
                { "Raúl Ramírez", new Dictionary<string, int> { { "Vitas Gerulaitis", 1 } } },
                { "Björn Borg", new Dictionary<string, int> { { "Guillermo Vilas", 1 }, { "Roscoe Tanner", 2 }, { "Ilie Năstase", 2 }, { "Vitas Gerulaitis", 1 }, { "Jimmy Connors", 4 }, { "Sandy Mayer", 1 }, { "Tom Okker", 2 }, { "Gene Mayer", 1 }, { "Brian Gottfried", 1 }, { "John McEnroe", 1 }, { "Peter McNamara", 1 } } },
                { "John McEnroe", new Dictionary<string, int> { { "Phil Dent", 1 }, { "Peter Fleming", 1 }, { "Jimmy Connors", 2 }, { "Johan Kriek", 2 }, { "Rod Frawley", 1 }, { "Björn Borg", 1 }, { "Tim Mayotte", 1 }, { "Sandy Mayer", 1 }, { "Ivan Lendl", 1 }, { "Chris Lewis", 1 }, { "John Sadri", 1 }, { "Pat Cash", 1 }, { "Mats Wilander", 1 }, { "Guy Forget", 1 } } },
                { "Vitas Gerulaitis", new Dictionary<string, int> { { "Billy Martin", 1 }, { "Brian Gottfried", 1 } } },
                { "Tom Okker", new Dictionary<string, int> { { "Ilie Năstase", 1 } } },
                { "Pat DuPré", new Dictionary<string, int> { { "Adriano Panatta", 1 } } },
                { "Brian Gottfried", new Dictionary<string, int> { { "Wojciech Fibak", 1 } } },
                { "Rod Frawley", new Dictionary<string, int> { { "Tim Mayotte", 1 } } },
                { "Tim Mayotte", new Dictionary<string, int> { { "Brian Teacher", 1 } } },
                { "Mark Edmondson", new Dictionary<string, int> { { "Vitas Gerulaitis", 1 } } },
                { "Kevin Curren", new Dictionary<string, int> { { "Tim Mayotte", 1 }, { "John McEnroe", 1 }, { "Jimmy Connors", 1 } } },
                { "Chris Lewis", new Dictionary<string, int> { { "Mel Purcell", 1 }, { "Kevin Curren", 1 } } },
                { "Ivan Lendl", new Dictionary<string, int> { { "Roscoe Tanner", 1 }, { "Tomáš Šmíd", 1 }, { "Tim Mayotte", 2 }, { "Slobodan Živojinović", 1 }, { "Henri Leconte", 1 }, { "Stefan Edberg", 1 }, { "Dan Goldie", 1 }, { "Brad Pearce", 1 } } },
                { "Pat Cash", new Dictionary<string, int> { { "Andrés Gómez", 1 }, { "Mats Wilander", 1 }, { "Jimmy Connors", 1 }, { "Ivan Lendl", 1 } } },
                { "Anders Järryd", new Dictionary<string, int> { { "Heinz Günthardt", 1 } } },
                { "Boris Becker", new Dictionary<string, int> { { "Henri Leconte", 2 }, { "Anders Järryd", 1 }, { "Kevin Curren", 1 }, { "Miloslav Mečíř", 1 }, { "Ivan Lendl", 3 }, { "Pat Cash", 1 }, { "Paul Chamberlin", 1 }, { "Stefan Edberg", 1 }, { "Brad Gilbert", 1 }, { "Goran Ivanišević", 1 }, { "Guy Forget", 1 }, { "David Wheaton", 1 }, { "Michael Stich", 1 }, { "Christian Bergström", 1 }, { "Cédric Pioline", 1 }, { "Andre Agassi", 1 } } },
                { "Slobodan Živojinović", new Dictionary<string, int> { { "Ramesh Krishnan", 1 } } },
                { "Henri Leconte", new Dictionary<string, int> { { "Pat Cash", 1 } } },
                { "Stefan Edberg", new Dictionary<string, int> { { "Anders Järryd", 1 }, { "Patrik Kühnen", 1 }, { "Miloslav Mečíř", 1 }, { "Boris Becker", 2 }, { "Tim Mayotte", 1 }, { "John McEnroe", 1 }, { "Christian Bergström", 1 }, { "Ivan Lendl", 1 }, { "Thierry Champion", 1 }, { "Cédric Pioline", 1 } } },
                { "Miloslav Mečíř", new Dictionary<string, int> { { "Mats Wilander", 1 } } },
                { "Goran Ivanišević", new Dictionary<string, int> { { "Kevin Curren", 1 }, { "Stefan Edberg", 1 }, { "Pete Sampras", 1 }, { "Guy Forget", 1 }, { "Boris Becker", 1 }, { "Yevgeny Kafelnikov", 1 }, { "Jan Siemerink", 1 }, { "Richard Krajicek", 1 }, { "Marat Safin", 1 }, { "Tim Henman", 1 }, { "Pat Rafter", 1 } } },
                { "Michael Stich", new Dictionary<string, int> { { "Jim Courier", 1 }, { "Stefan Edberg", 1 }, { "Boris Becker", 1 }, { "Tim Henman", 1 } } },
                { "David Wheaton", new Dictionary<string, int> { { "Andre Agassi", 1 } } },
                { "Andre Agassi", new Dictionary<string, int> { { "Boris Becker", 1 }, { "John McEnroe", 1 }, { "Goran Ivanišević", 1 }, { "Jacco Eltingh", 1 }, { "Gustavo Kuerten", 1 }, { "Pat Rafter", 1 }, { "Mark Philippoussis", 1 }, { "Nicolas Escudé", 1 } } },
                { "Pete Sampras", new Dictionary<string, int> { { "Michael Stich", 1 }, { "Andre Agassi", 2 }, { "Boris Becker", 3 }, { "Jim Courier", 1 }, { "Michael Chang", 1 }, { "Todd Martin", 1 }, { "Goran Ivanišević", 3 }, { "Shuzo Matsuoka", 1 }, { "Todd Woodbridge", 1 }, { "Cédric Pioline", 1 }, { "Mark Philippoussis", 2 }, { "Tim Henman", 2 }, { "Jan-Michael Gambill", 1 }, { "Vladimir Voltchkov", 1 }, { "Pat Rafter", 1 } } },
                { "Jim Courier", new Dictionary<string, int> { { "Todd Martin", 1 }, { "Stefan Edberg", 1 } } },
                { "Todd Martin", new Dictionary<string, int> { { "Wayne Ferreira", 1 }, { "Tim Henman", 1 } } },
                { "Richard Krajicek", new Dictionary<string, int> { { "Pete Sampras", 1 }, { "Jason Stoltenberg", 1 }, { "MaliVai Washington", 1 }, { "Davide Sanguinetti", 1 } } },
                { "Jason Stoltenberg", new Dictionary<string, int> { { "Goran Ivanišević", 1 } } },
                { "MaliVai Washington", new Dictionary<string, int> { { "Alex Rădulescu", 1 }, { "Todd Martin", 1 } } },
                { "Todd Woodbridge", new Dictionary<string, int> { { "Nicolas Kiefer", 1 } } },
                { "Cédric Pioline", new Dictionary<string, int> { { "Greg Rusedski", 1 }, { "Michael Stich", 1 } } },
                { "Tim Henman", new Dictionary<string, int> { { "Petr Korda", 1 }, { "Cédric Pioline", 1 }, { "Roger Federer", 1 }, { "André Sá", 1 } } },
                { "Pat Rafter", new Dictionary<string, int> { { "Todd Martin", 1 }, { "Alexander Popp", 1 }, { "Andre Agassi", 2 }, { "Thomas Enqvist", 1 } } },
                { "Vladimir Voltchkov", new Dictionary<string, int> { { "Byron Black", 1 } } },
                { "Lleyton Hewitt", new Dictionary<string, int> { { "Sjeng Schalken", 1 }, { "Tim Henman", 1 }, { "David Nalbandian", 1 }, { "Feliciano López", 1 } } },
                { "Xavier Malisse", new Dictionary<string, int> { { "Richard Krajicek", 1 } } },
                { "David Nalbandian", new Dictionary<string, int> { { "Nicolás Lapentti", 1 }, { "Xavier Malisse", 1 } } },
                { "Andy Roddick", new Dictionary<string, int> { { "Jonas Björkman", 1 }, { "Sjeng Schalken", 1 }, { "Mario Ančić", 1 }, { "Sébastien Grosjean", 1 }, { "Thomas Johansson", 1 }, { "Lleyton Hewitt", 1 }, { "Andy Murray", 1 } } },
                { "Roger Federer", new Dictionary<string, int> { { "Sjeng Schalken", 1 }, { "Andy Roddick", 4 }, { "Mark Philippoussis", 1 }, { "Lleyton Hewitt", 2 }, { "Sébastien Grosjean", 1 }, { "Fernando González", 1 }, { "Mario Ančić", 2 }, { "Jonas Björkman", 1 }, { "Rafael Nadal", 2 }, { "Juan Carlos Ferrero", 1 }, { "Richard Gasquet", 1 }, { "Marat Safin", 1 }, { "Ivo Karlović", 1 }, { "Tommy Haas", 1 }, { "Mikhail Youzhny", 1 }, { "Novak Djokovic", 1 }, { "Andy Murray", 2 }, { "Stan Wawrinka", 1 }, { "Milos Raonic", 2 }, { "Gilles Simon", 1 }, { "Marin Čilić", 2 }, { "Tomáš Berdych", 1 } } },
                { "Sébastien Grosjean", new Dictionary<string, int> { { "Tim Henman", 1 }, { "Florian Mayer", 1 } } },
                { "Mark Philippoussis", new Dictionary<string, int> { { "Alexander Popp", 1 }, { "Sébastien Grosjean", 1 } } },
                { "Mario Ančić", new Dictionary<string, int> { { "Tim Henman", 1 } } },
                { "Thomas Johansson", new Dictionary<string, int> { { "David Nalbandian", 1 } } },
                { "Jonas Björkman", new Dictionary<string, int> { { "Radek Štěpánek", 1 } } },
                { "Marcos Baghdatis", new Dictionary<string, int> { { "Lleyton Hewitt", 1 } } },
                { "Rafael Nadal", new Dictionary<string, int> { { "Jarkko Nieminen", 1 }, { "Marcos Baghdatis", 1 }, { "Tomáš Berdych", 2 }, { "Novak Djokovic", 1 }, { "Andy Murray", 3 }, { "Rainer Schüttler", 1 }, { "Roger Federer", 1 }, { "Robin Söderling", 1 }, { "Mardy Fish", 1 }, { "Juan Martín del Potro", 1 } } },
                { "Richard Gasquet", new Dictionary<string, int> { { "Andy Roddick", 1 }, { "Stan Wawrinka", 1 } } },
                { "Novak Djokovic", new Dictionary<string, int> { { "Marcos Baghdatis", 1 }, { "Lu Yen-hsun", 1 }, { "Bernard Tomic", 1 }, { "Jo-Wilfried Tsonga", 1 }, { "Rafael Nadal", 2 }, { "Florian Mayer", 1 }, { "Tomáš Berdych", 1 }, { "Juan Martín del Potro", 1 }, { "Marin Čilić", 2 }, { "Grigor Dimitrov", 1 }, { "Roger Federer", 2 }, { "Richard Gasquet", 1 }, { "Kei Nishikori", 1 }, { "Kevin Anderson", 1 } } },
                { "Marat Safin", new Dictionary<string, int> { { "Feliciano López", 1 } } },
                { "Rainer Schüttler", new Dictionary<string, int> { { "Arnaud Clément", 1 } } },
                { "Andy Murray", new Dictionary<string, int> { { "Juan Carlos Ferrero", 1 }, { "Jo-Wilfried Tsonga", 3 }, { "Feliciano López", 1 }, { "David Ferrer", 1 }, { "Fernando Verdasco", 1 }, { "Jerzy Janowicz", 1 }, { "Novak Djokovic", 1 }, { "Vasek Pospisil", 1 }, { "Tomáš Berdych", 1 }, { "Milos Raonic", 1 } } },
                { "Tommy Haas", new Dictionary<string, int> { { "Novak Djokovic", 1 } } },
                { "Tomáš Berdych", new Dictionary<string, int> { { "Roger Federer", 1 }, { "Novak Djokovic", 2 }, { "Lucas Pouille", 1 } } },
                { "Jo-Wilfried Tsonga", new Dictionary<string, int> { { "Roger Federer", 1 }, { "Philipp Kohlschreiber", 1 } } },
                { "Juan Martín del Potro", new Dictionary<string, int> { { "David Ferrer", 1 } } },
                { "Jerzy Janowicz", new Dictionary<string, int> { { "Łukasz Kubot", 1 } } },
                { "Grigor Dimitrov", new Dictionary<string, int> { { "Andy Murray", 1 } } },
                { "Milos Raonic", new Dictionary<string, int> { { "Nick Kyrgios", 1 }, { "Sam Querrey", 1 }, { "Roger Federer", 1 } } },
                { "Sam Querrey", new Dictionary<string, int> { { "Andy Murray", 1 } } },
                { "Marin Čilić", new Dictionary<string, int> { { "Gilles Müller", 1 }, { "Sam Querrey", 1 } } },
                { "Kevin Anderson", new Dictionary<string, int> { { "Roger Federer", 1 }, { "John Isner", 1 } } },
                { "John Isner", new Dictionary<string, int> { { "Milos Raonic", 1 } } }
            };
        }
        
        static Dictionary<string, Dictionary<string, int>> wimbledonWomens()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "Billie Jean King", new Dictionary<string, int> { { "Lesley Turner Bowrey", 1 }, { "Ann Jones", 1 }, { "Judy Tegart", 2 }, { "Rosemary Casals", 2 }, { "Karen Krantzcke", 1 }, { "Françoise Dürr", 2 }, { "Virginia Wade", 1 }, { "Evonne Goolagong", 3 }, { "Kerry Reid", 1 }, { "Chris Evert", 2 }, { "Olga Morozova", 1 }, { "Tracy Austin", 1 }, { "Kathy Jordan", 1 } } },
                { "Ann Jones", new Dictionary<string, int> { { "Françoise Dürr", 1 }, { "Nancy Richey", 1 }, { "Margaret Court", 1 }, { "Billie Jean King", 1 } } },
                { "Nancy Richey", new Dictionary<string, int> { { "Maria Bueno", 1 } } },
                { "Judy Tegart", new Dictionary<string, int> { { "Margaret Court", 1 }, { "Nancy Richey", 1 }, { "Kerry Reid", 1 } } },
                { "Margaret Court", new Dictionary<string, int> { { "Julie Heldman", 1 }, { "Helga Niessen", 1 }, { "Rosemary Casals", 1 }, { "Billie Jean King", 1 }, { "Winnie Shaw", 1 }, { "Judy Tegart", 1 }, { "Olga Morozova", 1 }, { "Martina Navratilova", 1 } } },
                { "Rosemary Casals", new Dictionary<string, int> { { "Lesley Turner Bowrey", 1 }, { "Winnie Shaw", 1 }, { "Nancy Richey", 1 } } },
                { "Françoise Dürr", new Dictionary<string, int> { { "Cici Martinez", 1 } } },
                { "Evonne Goolagong", new Dictionary<string, int> { { "Nancy Richey", 1 }, { "Billie Jean King", 1 }, { "Margaret Court", 2 }, { "Françoise Dürr", 1 }, { "Chris Evert", 2 }, { "Virginia Wade", 4 }, { "Rosemary Casals", 1 }, { "Virginia Ruzici", 1 }, { "Wendy Turnbull", 1 }, { "Tracy Austin", 1 } } },
                { "Chris Evert", new Dictionary<string, int> { { "Patti Hogan", 1 }, { "Rosemary Casals", 1 }, { "Margaret Court", 1 }, { "Helga Niessen", 1 }, { "Kerry Reid", 1 }, { "Olga Morozova", 2 }, { "Betty Stöve", 1 }, { "Martina Navratilova", 2 }, { "Evonne Goolagong", 2 }, { "Billie Jean King", 3 }, { "Virginia Wade", 1 }, { "Wendy Turnbull", 1 }, { "Andrea Jaeger", 1 }, { "Mima Jaušovec", 1 }, { "Pam Shriver", 1 }, { "Hana Mandlíková", 2 }, { "Barbara Potter", 2 }, { "Carina Karlsson", 1 }, { "Kathy Rinaldi", 1 }, { "Helena Suková", 2 }, { "Claudia Kohde-Kilsch", 1 }, { "Laura Golarsa", 1 } } },
                { "Olga Morozova", new Dictionary<string, int> { { "Billie Jean King", 1 }, { "Virginia Wade", 1 } } },
                { "Virginia Wade", new Dictionary<string, int> { { "Linky Boshoff", 1 }, { "Kerry Reid", 1 }, { "Rosemary Casals", 1 }, { "Chris Evert", 1 }, { "Betty Stöve", 1 }, { "Mima Jaušovec", 1 } } },
                { "Kerry Reid", new Dictionary<string, int> { { "Evonne Goolagong", 1 } } },
                { "Martina Navratilova", new Dictionary<string, int> { { "Sue Barker", 1 }, { "Marise Kruger", 1 }, { "Evonne Goolagong", 1 }, { "Chris Evert", 7 }, { "Dianne Fromholtz", 2 }, { "Tracy Austin", 1 }, { "Billie Jean King", 1 }, { "Virginia Ruzici", 1 }, { "JoAnne Russell", 1 }, { "Bettina Bunge", 2 }, { "Jennifer Mundel", 1 }, { "Yvonne Vermaak", 1 }, { "Andrea Jaeger", 1 }, { "Manuela Maleeva", 1 }, { "Kathy Jordan", 1 }, { "Pam Shriver", 1 }, { "Zina Garrison", 2 }, { "Gabriela Sabatini", 2 }, { "Hana Mandlíková", 1 }, { "Steffi Graf", 1 }, { "Rosalyn Fairbank", 1 }, { "Gretchen Rush", 1 }, { "Catarina Lindqvist", 1 }, { "Katerina Maleeva", 2 }, { "Natasha Zvereva", 1 }, { "Jana Novotná", 1 }, { "Gigi Fernández", 1 } } },
                { "Sue Barker", new Dictionary<string, int> { { "Kerry Reid", 1 } } },
                { "Betty Stöve", new Dictionary<string, int> { { "Martina Navratilova", 1 }, { "Sue Barker", 1 } } },
                { "Tracy Austin", new Dictionary<string, int> { { "Billie Jean King", 1 }, { "Greer Stevens", 1 } } },
                { "Pam Shriver", new Dictionary<string, int> { { "Tracy Austin", 1 }, { "Helena Suková", 1 }, { "Zina Garrison", 1 } } },
                { "Hana Mandlíková", new Dictionary<string, int> { { "Wendy Turnbull", 1 }, { "Martina Navratilova", 1 }, { "Jo Durie", 1 }, { "Lori McNeil", 1 }, { "Chris Evert", 1 } } },
                { "Bettina Bunge", new Dictionary<string, int> { { "Anne Smith", 1 } } },
                { "Yvonne Vermaak", new Dictionary<string, int> { { "Virginia Wade", 1 } } },
                { "Andrea Jaeger", new Dictionary<string, int> { { "Barbara Potter", 1 }, { "Billie Jean King", 1 } } },
                { "Kathy Jordan", new Dictionary<string, int> { { "Pam Shriver", 1 } } },
                { "Kathy Rinaldi", new Dictionary<string, int> { { "Helena Suková", 1 } } },
                { "Zina Garrison", new Dictionary<string, int> { { "Molly Van Nostrand", 1 }, { "Monica Seles", 1 }, { "Steffi Graf", 1 } } },
                { "Gabriela Sabatini", new Dictionary<string, int> { { "Catarina Lindqvist", 1 }, { "Natasha Zvereva", 1 }, { "Laura Arraya", 1 }, { "Jennifer Capriati", 2 } } },
                { "Steffi Graf", new Dictionary<string, int> { { "Gabriela Sabatini", 3 }, { "Pam Shriver", 2 }, { "Pascale Paradis", 1 }, { "Martina Navratilova", 2 }, { "Arantxa Sánchez", 3 }, { "Chris Evert", 1 }, { "Jana Novotná", 4 }, { "Zina Garrison", 1 }, { "Mary Joe Fernández", 2 }, { "Natasha Zvereva", 1 }, { "Monica Seles", 1 }, { "Jennifer Capriati", 1 }, { "Conchita Martínez", 1 }, { "Kimiko Date", 1 }, { "Venus Williams", 1 }, { "Mirjana Lučić-Baroni", 1 } } },
                { "Catarina Lindqvist", new Dictionary<string, int> { { "Rosalyn Fairbank", 1 } } },
                { "Mary Joe Fernández", new Dictionary<string, int> { { "Arantxa Sánchez", 1 } } },
                { "Jennifer Capriati", new Dictionary<string, int> { { "Martina Navratilova", 1 }, { "Serena Williams", 1 } } },
                { "Monica Seles", new Dictionary<string, int> { { "Nathalie Tauziat", 1 }, { "Martina Navratilova", 1 } } },
                { "Conchita Martínez", new Dictionary<string, int> { { "Helena Suková", 1 }, { "Lindsay Davenport", 1 }, { "Lori McNeil", 1 }, { "Martina Navratilova", 1 }, { "Gabriela Sabatini", 1 } } },
                { "Jana Novotná", new Dictionary<string, int> { { "Gabriela Sabatini", 1 }, { "Martina Navratilova", 1 }, { "Kimiko Date", 1 }, { "Yayuk Basuki", 1 }, { "Arantxa Sánchez", 1 }, { "Venus Williams", 1 }, { "Martina Hingis", 1 }, { "Nathalie Tauziat", 1 } } },
                { "Lori McNeil", new Dictionary<string, int> { { "Larisa Neiland", 1 } } },
                { "Gigi Fernández", new Dictionary<string, int> { { "Zina Garrison", 1 } } },
                { "Arantxa Sánchez", new Dictionary<string, int> { { "Conchita Martínez", 1 }, { "Judith Wiesner", 1 }, { "Meredith McGrath", 1 }, { "Nathalie Tauziat", 1 } } },
                { "Kimiko Date", new Dictionary<string, int> { { "Mary Pierce", 1 } } },
                { "Meredith McGrath", new Dictionary<string, int> { { "Mary Joe Fernández", 1 } } },
                { "Martina Hingis", new Dictionary<string, int> { { "Denisa Chládková", 1 }, { "Anna Kournikova", 1 }, { "Jana Novotná", 1 }, { "Arantxa Sánchez", 1 } } },
                { "Anna Kournikova", new Dictionary<string, int> { { "Iva Majoli", 1 } } },
                { "Natasha Zvereva", new Dictionary<string, int> { { "Monica Seles", 1 } } },
                { "Nathalie Tauziat", new Dictionary<string, int> { { "Lindsay Davenport", 1 }, { "Natasha Zvereva", 1 } } },
                { "Alexandra Stevenson", new Dictionary<string, int> { { "Jelena Dokic", 1 } } },
                { "Lindsay Davenport", new Dictionary<string, int> { { "Jana Novotná", 1 }, { "Alexandra Stevenson", 1 }, { "Steffi Graf", 1 }, { "Monica Seles", 1 }, { "Jelena Dokic", 1 }, { "Kim Clijsters", 1 }, { "Karolina Šprem", 1 }, { "Svetlana Kuznetsova", 1 }, { "Amélie Mauresmo", 1 } } },
                { "Mirjana Lučić-Baroni", new Dictionary<string, int> { { "Nathalie Tauziat", 1 } } },
                { "Venus Williams", new Dictionary<string, int> { { "Martina Hingis", 1 }, { "Serena Williams", 2 }, { "Lindsay Davenport", 4 }, { "Nathalie Tauziat", 1 }, { "Justine Henin", 2 }, { "Elena Likhovtseva", 1 }, { "Kim Clijsters", 1 }, { "Mary Pierce", 1 }, { "Maria Sharapova", 1 }, { "Svetlana Kuznetsova", 1 }, { "Ana Ivanovic", 1 }, { "Marion Bartoli", 1 }, { "Tamarine Tanasugarn", 1 }, { "Elena Dementieva", 1 }, { "Agnieszka Radwańska", 1 }, { "Dinara Safina", 1 }, { "Yaroslava Shvedova", 1 }, { "Jeļena Ostapenko", 1 }, { "Johanna Konta", 1 } } },
                { "Serena Williams", new Dictionary<string, int> { { "Lisa Raymond", 1 }, { "Daniela Hantuchová", 1 }, { "Amélie Mauresmo", 2 }, { "Venus Williams", 3 }, { "Jennifer Capriati", 2 }, { "Justine Henin", 1 }, { "Agnieszka Radwańska", 2 }, { "Zheng Jie", 1 }, { "Victoria Azarenka", 3 }, { "Elena Dementieva", 1 }, { "Li Na", 1 }, { "Petra Kvitová", 2 }, { "Vera Zvonareva", 1 }, { "Maria Sharapova", 1 }, { "Garbiñe Muguruza", 1 }, { "Elena Vesnina", 1 }, { "Angelique Kerber", 1 }, { "Camila Giorgi", 1 }, { "Julia Görges", 1 } } },
                { "Jelena Dokic", new Dictionary<string, int> { { "Magüi Serna", 1 } } },
                { "Justine Henin", new Dictionary<string, int> { { "Conchita Martínez", 1 }, { "Jennifer Capriati", 1 }, { "Monica Seles", 1 }, { "Svetlana Kuznetsova", 1 }, { "Séverine Beltrame", 1 }, { "Kim Clijsters", 1 }, { "Serena Williams", 1 } } },
                { "Amélie Mauresmo", new Dictionary<string, int> { { "Jennifer Capriati", 1 }, { "Paola Suárez", 1 }, { "Anastasia Myskina", 2 }, { "Maria Sharapova", 1 }, { "Justine Henin", 1 } } },
                { "Kim Clijsters", new Dictionary<string, int> { { "Silvia Farina Elia", 1 }, { "Li Na", 1 } } },
                { "Maria Sharapova", new Dictionary<string, int> { { "Ai Sugiyama", 1 }, { "Lindsay Davenport", 1 }, { "Serena Williams", 1 }, { "Nadia Petrova", 1 }, { "Elena Dementieva", 1 }, { "Dominika Cibulková", 1 }, { "Sabine Lisicki", 1 }, { "CoCo Vandeweghe", 1 } } },
                { "Marion Bartoli", new Dictionary<string, int> { { "Michaëlla Krajicek", 1 }, { "Justine Henin", 1 }, { "Sloane Stephens", 1 }, { "Kirsten Flipkens", 1 }, { "Sabine Lisicki", 1 } } },
                { "Ana Ivanovic", new Dictionary<string, int> { { "Nicole Vaidišová", 1 } } },
                { "Zheng Jie", new Dictionary<string, int> { { "Nicole Vaidišová", 1 } } },
                { "Elena Dementieva", new Dictionary<string, int> { { "Nadia Petrova", 1 }, { "Francesca Schiavone", 1 } } },
                { "Dinara Safina", new Dictionary<string, int> { { "Sabine Lisicki", 1 } } },
                { "Petra Kvitová", new Dictionary<string, int> { { "Kaia Kanepi", 1 }, { "Tsvetana Pironkova", 1 }, { "Victoria Azarenka", 1 }, { "Maria Sharapova", 1 }, { "Barbora Strýcová", 1 }, { "Lucie Šafářová", 1 }, { "Eugenie Bouchard", 1 } } },
                { "Vera Zvonareva", new Dictionary<string, int> { { "Kim Clijsters", 1 }, { "Tsvetana Pironkova", 1 } } },
                { "Tsvetana Pironkova", new Dictionary<string, int> { { "Venus Williams", 1 } } },
                { "Sabine Lisicki", new Dictionary<string, int> { { "Marion Bartoli", 1 }, { "Kaia Kanepi", 1 }, { "Agnieszka Radwańska", 1 } } },
                { "Victoria Azarenka", new Dictionary<string, int> { { "Tamira Paszek", 2 } } },
                { "Angelique Kerber", new Dictionary<string, int> { { "Sabine Lisicki", 1 }, { "Simona Halep", 1 }, { "Venus Williams", 1 }, { "Daria Kasatkina", 1 }, { "Jeļena Ostapenko", 1 }, { "Serena Williams", 1 } } },
                { "Agnieszka Radwańska", new Dictionary<string, int> { { "Maria Kirilenko", 1 }, { "Angelique Kerber", 1 }, { "Li Na", 1 }, { "Madison Keys", 1 } } },
                { "Kirsten Flipkens", new Dictionary<string, int> { { "Petra Kvitová", 1 } } },
                { "Eugenie Bouchard", new Dictionary<string, int> { { "Angelique Kerber", 1 }, { "Simona Halep", 1 } } },
                { "Simona Halep", new Dictionary<string, int> { { "Sabine Lisicki", 1 } } },
                { "Lucie Šafářová", new Dictionary<string, int> { { "Ekaterina Makarova", 1 } } },
                { "Garbiñe Muguruza", new Dictionary<string, int> { { "Timea Bacsinszky", 1 }, { "Agnieszka Radwańska", 1 }, { "Svetlana Kuznetsova", 1 }, { "Venus Williams", 1 } } },
                { "Elena Vesnina", new Dictionary<string, int> { { "Dominika Cibulková", 1 } } },
                { "Johanna Konta", new Dictionary<string, int> { { "Simona Halep", 1 } } },
                { "Jeļena Ostapenko", new Dictionary<string, int> { { "Dominika Cibulková", 1 } } },
                { "Julia Görges", new Dictionary<string, int> { { "Kiki Bertens", 1 } } }
            };
        }
        
        static Dictionary<string, Dictionary<string, int>> usOpenMens()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "Arthur Ashe", new Dictionary<string, int> { { "Tom Okker", 1 }, { "Clark Graebner", 1 }, { "Cliff Drysdale", 1 }, { "Ken Rosewall", 1 }, { "Manuel Orantes", 1 }, { "Cliff Richey", 1 }, { "Stan Smith", 1 } } },
                { "Tom Okker", new Dictionary<string, int> { { "Ken Rosewall", 1 }, { "Pancho Gonzales", 1 }, { "Clark Graebner", 1 } } },
                { "Clark Graebner", new Dictionary<string, int> { { "John Newcombe", 1 } } },
                { "Ken Rosewall", new Dictionary<string, int> { { "Dennis Ralston", 1 }, { "Tony Roche", 1 }, { "John Newcombe", 2 }, { "Stan Smith", 1 }, { "Vijay Amritraj", 2 } } },
                { "Rod Laver", new Dictionary<string, int> { { "Tony Roche", 1 }, { "Arthur Ashe", 1 }, { "Roy Emerson", 1 } } },
                { "Tony Roche", new Dictionary<string, int> { { "John Newcombe", 1 }, { "Earl Butch Buchholz", 1 }, { "Cliff Richey", 1 }, { "Brian Fairlie", 1 } } },
                { "John Newcombe", new Dictionary<string, int> { { "Fred Stolle", 1 }, { "Arthur Ashe", 2 }, { "Jan Kodeš", 1 }, { "Ken Rosewall", 1 }, { "Jimmy Connors", 1 } } },
                { "Cliff Richey", new Dictionary<string, int> { { "Dennis Ralston", 1 }, { "Frew McMillan", 1 } } },
                { "Stan Smith", new Dictionary<string, int> { { "Jan Kodeš", 1 }, { "Tom Okker", 1 }, { "Marty Riessen", 1 }, { "Onny Parun", 1 } } },
                { "Jan Kodeš", new Dictionary<string, int> { { "Arthur Ashe", 1 }, { "Frank Froehling", 1 }, { "Stan Smith", 1 }, { "Nikola Pilić", 1 } } },
                { "Ilie Năstase", new Dictionary<string, int> { { "Arthur Ashe", 1 }, { "Tom Gorman", 1 }, { "Fred Stolle", 1 }, { "Dick Stockton", 1 } } },
                { "Tom Gorman", new Dictionary<string, int> { { "Roscoe Tanner", 1 } } },
                { "Jimmy Connors", new Dictionary<string, int> { { "Ken Rosewall", 1 }, { "Roscoe Tanner", 1 }, { "Alex Metreveli", 1 }, { "Björn Borg", 3 }, { "Andrew Pattison", 1 }, { "Guillermo Vilas", 2 }, { "Jan Kodeš", 1 }, { "Corrado Barazzutti", 1 }, { "Manuel Orantes", 1 }, { "John McEnroe", 1 }, { "Brian Gottfried", 1 }, { "Pat Dupre", 1 }, { "Eliot Teltscher", 3 }, { "Ivan Lendl", 2 }, { "Rodney Harmon", 1 }, { "Bill Scanlon", 1 }, { "John Lloyd", 1 }, { "Heinz Günthardt", 1 }, { "Brad Gilbert", 1 }, { "Paul Haarhuis", 1 } } },
                { "Roscoe Tanner", new Dictionary<string, int> { { "Stan Smith", 1 }, { "Björn Borg", 1 } } },
                { "Manuel Orantes", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Guillermo Vilas", 1 }, { "Ilie Năstase", 1 } } },
                { "Björn Borg", new Dictionary<string, int> { { "Eddie Dibbs", 1 }, { "Ilie Năstase", 1 }, { "Manuel Orantes", 1 }, { "Vitas Gerulaitis", 1 }, { "Raúl Ramírez", 1 }, { "Johan Kriek", 1 }, { "Roscoe Tanner", 2 }, { "Jimmy Connors", 1 } } },
                { "Guillermo Vilas", new Dictionary<string, int> { { "Jaime Fillol", 1 }, { "Eddie Dibbs", 1 }, { "Jimmy Connors", 1 }, { "Harold Solomon", 1 }, { "Raymond Moore", 1 }, { "Tom Gullikson", 1 } } },
                { "Harold Solomon", new Dictionary<string, int> { { "Dick Stockton", 1 } } },
                { "Corrado Barazzutti", new Dictionary<string, int> { { "Brian Gottfried", 1 } } },
                { "Vitas Gerulaitis", new Dictionary<string, int> { { "Johan Kriek", 2 }, { "Roscoe Tanner", 1 }, { "Bruce Manson", 1 } } },
                { "John McEnroe", new Dictionary<string, int> { { "Butch Walts", 1 }, { "Vitas Gerulaitis", 2 }, { "Jimmy Connors", 3 }, { "Eddie Dibbs", 1 }, { "Björn Borg", 2 }, { "Ivan Lendl", 2 }, { "Ramesh Krishnan", 1 }, { "Gene Mayer", 2 }, { "Mats Wilander", 1 }, { "Joakim Nyström", 1 }, { "David Wheaton", 1 } } },
                { "Johan Kriek", new Dictionary<string, int> { { "Wojciech Fibak", 1 } } },
                { "Ivan Lendl", new Dictionary<string, int> { { "John McEnroe", 3 }, { "Kim Warwick", 1 }, { "Jimmy Arias", 1 }, { "Mats Wilander", 2 }, { "Pat Cash", 1 }, { "Andrés Gómez", 1 }, { "Jimmy Connors", 2 }, { "Yannick Noah", 1 }, { "Miloslav Mečíř", 1 }, { "Stefan Edberg", 1 }, { "Henri Leconte", 1 }, { "Andre Agassi", 2 }, { "Derrick Rostagno", 1 }, { "Tim Mayotte", 1 }, { "Michael Stich", 1 } } },
                { "Bill Scanlon", new Dictionary<string, int> { { "Mark Dickson", 1 } } },
                { "Jimmy Arias", new Dictionary<string, int> { { "Yannick Noah", 1 } } },
                { "Pat Cash", new Dictionary<string, int> { { "Mats Wilander", 1 } } },
                { "Mats Wilander", new Dictionary<string, int> { { "Anders Järryd", 1 }, { "Stefan Edberg", 1 }, { "Miloslav Mečíř", 1 }, { "Ivan Lendl", 1 }, { "Darren Cahill", 1 }, { "Emilio Sánchez", 1 } } },
                { "Miloslav Mečíř", new Dictionary<string, int> { { "Boris Becker", 1 }, { "Joakim Nyström", 1 } } },
                { "Stefan Edberg", new Dictionary<string, int> { { "Tim Wilkison", 1 }, { "Ramesh Krishnan", 1 }, { "Jim Courier", 1 }, { "Ivan Lendl", 2 }, { "Javier Sánchez", 1 }, { "Pete Sampras", 1 }, { "Michael Chang", 1 } } },
                { "Boris Becker", new Dictionary<string, int> { { "Milan Šrejber", 1 }, { "Ivan Lendl", 1 }, { "Aaron Krickstein", 2 }, { "Yannick Noah", 1 }, { "Patrick McEnroe", 1 } } },
                { "Andre Agassi", new Dictionary<string, int> { { "Jimmy Connors", 2 }, { "Boris Becker", 2 }, { "Andrei Cherkasov", 1 }, { "Michael Stich", 1 }, { "Todd Martin", 2 }, { "Thomas Muster", 2 }, { "Petr Korda", 1 }, { "Yevgeny Kafelnikov", 1 }, { "Nicolas Escudé", 1 }, { "Lleyton Hewitt", 1 }, { "Max Mirnyi", 1 }, { "Guillermo Coria", 1 }, { "Robby Ginepri", 1 }, { "James Blake", 1 } } },
                { "Darren Cahill", new Dictionary<string, int> { { "Aaron Krickstein", 1 } } },
                { "Aaron Krickstein", new Dictionary<string, int> { { "Jay Berger", 1 } } },
                { "Pete Sampras", new Dictionary<string, int> { { "Andre Agassi", 4 }, { "John McEnroe", 1 }, { "Ivan Lendl", 1 }, { "Jim Courier", 2 }, { "Alexander Volkov", 2 }, { "Cédric Pioline", 1 }, { "Michael Chang", 2 }, { "Byron Black", 1 }, { "Goran Ivanišević", 1 }, { "Àlex Corretja", 1 }, { "Karol Kučera", 1 }, { "Lleyton Hewitt", 1 }, { "Richard Krajicek", 1 }, { "Marat Safin", 1 }, { "Sjeng Schalken", 1 }, { "Andy Roddick", 1 } } },
                { "Jim Courier", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Pete Sampras", 1 }, { "Andre Agassi", 1 }, { "Michael Chang", 1 } } },
                { "Michael Chang", new Dictionary<string, int> { { "Wayne Ferreira", 1 }, { "Andre Agassi", 1 }, { "Javier Sánchez", 1 }, { "Marcelo Ríos", 1 } } },
                { "Cédric Pioline", new Dictionary<string, int> { { "Wally Masur", 1 }, { "Andrei Medvedev", 1 }, { "Gustavo Kuerten", 1 } } },
                { "Wally Masur", new Dictionary<string, int> { { "Magnus Larsson", 1 } } },
                { "Alexander Volkov", new Dictionary<string, int> { { "Thomas Muster", 1 } } },
                { "Michael Stich", new Dictionary<string, int> { { "Karel Nováček", 1 }, { "Jonas Björkman", 1 } } },
                { "Karel Nováček", new Dictionary<string, int> { { "Jaime Yzaga", 1 } } },
                { "Todd Martin", new Dictionary<string, int> { { "Bernd Karbacher", 1 }, { "Cédric Pioline", 1 }, { "Slava Doseděl", 1 }, { "Thomas Johansson", 1 } } },
                { "Goran Ivanišević", new Dictionary<string, int> { { "Stefan Edberg", 1 } } },
                { "Patrick Rafter", new Dictionary<string, int> { { "Greg Rusedski", 1 }, { "Michael Chang", 1 }, { "Magnus Larsson", 1 }, { "Mark Philippoussis", 1 }, { "Pete Sampras", 1 }, { "Jonas Björkman", 1 } } },
                { "Greg Rusedski", new Dictionary<string, int> { { "Jonas Björkman", 1 }, { "Richard Krajicek", 1 } } },
                { "Jonas Björkman", new Dictionary<string, int> { { "Petr Korda", 1 } } },
                { "Mark Philippoussis", new Dictionary<string, int> { { "Carlos Moyà", 1 }, { "Thomas Johansson", 1 } } },
                { "Carlos Moyà", new Dictionary<string, int> { { "Magnus Larsson", 1 } } },
                { "Yevgeny Kafelnikov", new Dictionary<string, int> { { "Richard Krajicek", 1 }, { "Gustavo Kuerten", 1 } } },
                { "Marat Safin", new Dictionary<string, int> { { "Pete Sampras", 1 }, { "Todd Martin", 1 }, { "Nicolas Kiefer", 1 }, { "Mariano Zabaleta", 1 } } },
                { "Lleyton Hewitt", new Dictionary<string, int> { { "Arnaud Clément", 1 }, { "Pete Sampras", 1 }, { "Yevgeny Kafelnikov", 1 }, { "Andy Roddick", 1 }, { "Younes El Aynaoui", 1 }, { "Joachim Johansson", 1 }, { "Tommy Haas", 1 }, { "Jarkko Nieminen", 1 } } },
                { "Sjeng Schalken", new Dictionary<string, int> { { "Fernando González", 1 } } },
                { "Andy Roddick", new Dictionary<string, int> { { "Juan Carlos Ferrero", 1 }, { "David Nalbandian", 1 }, { "Sjeng Schalken", 1 }, { "Lleyton Hewitt", 1 }, { "Mikhail Youzhny", 1 } } },
                { "Juan Carlos Ferrero", new Dictionary<string, int> { { "Andre Agassi", 1 }, { "Lleyton Hewitt", 1 } } },
                { "David Nalbandian", new Dictionary<string, int> { { "Younes El Aynaoui", 1 } } },
                { "Roger Federer", new Dictionary<string, int> { { "Lleyton Hewitt", 2 }, { "Tim Henman", 1 }, { "Andre Agassi", 2 }, { "David Nalbandian", 1 }, { "James Blake", 1 }, { "Nikolay Davydenko", 2 }, { "Andy Roddick", 2 }, { "Novak Djokovic", 3 }, { "Gilles Müller", 1 }, { "Andy Murray", 1 }, { "Robin Söderling", 2 }, { "Jo-Wilfried Tsonga", 1 }, { "Gaël Monfils", 1 }, { "Richard Gasquet", 1 }, { "Stan Wawrinka", 1 } } },
                { "Tim Henman", new Dictionary<string, int> { { "Dominik Hrbatý", 1 } } },
                { "Joachim Johansson", new Dictionary<string, int> { { "Andy Roddick", 1 } } },
                { "Robby Ginepri", new Dictionary<string, int> { { "Guillermo Coria", 1 } } },
                { "Nikolay Davydenko", new Dictionary<string, int> { { "Tommy Haas", 2 } } },
                { "Mikhail Youzhny", new Dictionary<string, int> { { "Rafael Nadal", 1 }, { "Stan Wawrinka", 1 } } },
                { "Novak Djokovic", new Dictionary<string, int> { { "Carlos Moyà", 1 }, { "David Ferrer", 2 }, { "Andy Roddick", 1 }, { "Fernando Verdasco", 1 }, { "Gaël Monfils", 2 }, { "Roger Federer", 3 }, { "Janko Tipsarević", 1 }, { "Rafael Nadal", 1 }, { "Juan Martín del Potro", 2 }, { "Mikhail Youzhny", 1 }, { "Stan Wawrinka", 1 }, { "Andy Murray", 1 }, { "Feliciano López", 1 }, { "Marin Čilić", 1 }, { "Jo-Wilfried Tsonga", 1 }, { "John Millman", 1 }, { "Kei Nishikori", 1 } } },
                { "David Ferrer", new Dictionary<string, int> { { "Juan Ignacio Chela", 1 }, { "Janko Tipsarević", 1 } } },
                { "Rafael Nadal", new Dictionary<string, int> { { "Mardy Fish", 1 }, { "Fernando González", 1 }, { "Fernando Verdasco", 1 }, { "Mikhail Youzhny", 1 }, { "Novak Djokovic", 2 }, { "Andy Roddick", 1 }, { "Andy Murray", 1 }, { "Tommy Robredo", 1 }, { "Richard Gasquet", 1 }, { "Andrey Rublev", 1 }, { "Juan Martín del Potro", 1 }, { "Kevin Anderson", 1 }, { "Dominic Thiem", 1 } } },
                { "Andy Murray", new Dictionary<string, int> { { "Juan Martín del Potro", 1 }, { "Rafael Nadal", 1 }, { "John Isner", 1 }, { "Marin Čilić", 1 }, { "Tomáš Berdych", 1 }, { "Novak Djokovic", 1 } } },
                { "Juan Martín del Potro", new Dictionary<string, int> { { "Marin Čilić", 1 }, { "Rafael Nadal", 2 }, { "Roger Federer", 2 }, { "John Isner", 1 } } },
                { "Tomáš Berdych", new Dictionary<string, int> { { "Roger Federer", 1 } } },
                { "Stan Wawrinka", new Dictionary<string, int> { { "Andy Murray", 1 }, { "Kevin Anderson", 1 }, { "Juan Martín del Potro", 1 }, { "Kei Nishikori", 1 }, { "Novak Djokovic", 1 } } },
                { "Richard Gasquet", new Dictionary<string, int> { { "David Ferrer", 1 } } },
                { "Kei Nishikori", new Dictionary<string, int> { { "Stan Wawrinka", 1 }, { "Novak Djokovic", 1 }, { "Andy Murray", 1 }, { "Marin Čilić", 1 } } },
                { "Marin Čilić", new Dictionary<string, int> { { "Tomáš Berdych", 1 }, { "Roger Federer", 1 }, { "Kei Nishikori", 1 }, { "Jo-Wilfried Tsonga", 1 } } },
                { "Gaël Monfils", new Dictionary<string, int> { { "Lucas Pouille", 1 } } },
                { "Kevin Anderson", new Dictionary<string, int> { { "Sam Querrey", 1 }, { "Pablo Carreño Busta", 1 } } },
                { "Pablo Carreño Busta", new Dictionary<string, int> { { "Diego Schwartzman", 1 } } }
            };
        }
        
        static Dictionary<string, Dictionary<string, int>> usOpenWomens()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "Virginia Wade", new Dictionary<string, int> { { "Billie Jean King", 1 }, { "Ann Haydon-Jones", 1 }, { "Judy Tegart", 1 }, { "Julie Heldman", 1 }, { "Françoise Dürr", 1 }, { "Katja Ebbinghaus", 1 } } },
                { "Billie Jean King", new Dictionary<string, int> { { "Maria Bueno", 1 }, { "Maryna Godwin", 1 }, { "Rosemary Casals", 2 }, { "Chris Evert", 1 }, { "Laura duPont", 1 }, { "Kerry Reid", 1 }, { "Margaret Court", 1 }, { "Virginia Wade", 2 }, { "Evonne Goolagong", 1 }, { "Julie Heldman", 1 } } },
                { "Maria Bueno", new Dictionary<string, int> { { "Margaret Court", 1 } } },
                { "Ann Haydon-Jones", new Dictionary<string, int> { { "Peaches Bartkowicz", 1 } } },
                { "Margaret Court", new Dictionary<string, int> { { "Nancy Richey", 2 }, { "Virginia Wade", 2 }, { "Karen Krantzcke", 1 }, { "Rosemary Casals", 2 }, { "Helen Gourlay", 1 }, { "Evonne Goolagong", 1 }, { "Chris Evert", 1 } } },
                { "Nancy Richey", new Dictionary<string, int> { { "Rosemary Casals", 1 }, { "Billie Jean King", 1 }, { "Lesley Hunt", 1 } } },
                { "Rosemary Casals", new Dictionary<string, int> { { "Peaches Bartkowicz", 1 }, { "Virginia Wade", 1 }, { "Kerry Reid", 2 }, { "Joyce Williams", 1 } } },
                { "Chris Evert", new Dictionary<string, int> { { "Lesley Hunt", 2 }, { "Olga Morozova", 1 }, { "Rosemary Casals", 1 }, { "Evonne Cawley", 1 }, { "Martina Navratilova", 1 }, { "Kerry Reid", 1 }, { "Evonne Goolagong", 2 }, { "Mima Jaušovec", 2 }, { "Natasha Chmyreva", 1 }, { "Wendy Turnbull", 2 }, { "Betty Stöve", 1 }, { "Billie Jean King", 2 }, { "Pam Shriver", 1 }, { "Tracy Austin", 2 }, { "Hana Mandlíková", 4 }, { "Andrea Jaeger", 1 }, { "Bonnie Gadusek", 1 }, { "Jo Durie", 1 }, { "Carling Bassett", 1 }, { "Sylvia Hanika", 1 }, { "Claudia Kohde-Kilsch", 1 }, { "Manuela Maleeva", 2 } } },
                { "Kerry Reid", new Dictionary<string, int> { { "Judy Tegart", 1 }, { "Chris Evert", 1 }, { "Pam Teeguarden", 1 } } },
                { "Evonne Goolagong", new Dictionary<string, int> { { "Helga Masthoff", 1 }, { "Kerry Reid", 2 }, { "Chris Evert", 1 }, { "Dianne Fromholtz", 1 }, { "Rosemary Casals", 1 } } },
                { "Helga Masthoff", new Dictionary<string, int> { { "Julie Heldman", 1 } } },
                { "Julie Heldman", new Dictionary<string, int> { { "Nancy Richey Gunter", 1 } } },
                { "Evonne Cawley", new Dictionary<string, int> { { "Virginia Wade", 1 }, { "Kazuko Sawamatsu", 1 } } },
                { "Martina Navratilova", new Dictionary<string, int> { { "Margaret Court", 1 }, { "Mima Jaušovec", 1 }, { "Virginia Ruzici", 1 }, { "Kerry Reid", 1 }, { "Chris Evert", 3 }, { "Anne Smith", 1 }, { "Pam Shriver", 2 }, { "Sylvia Hanika", 1 }, { "Wendy Turnbull", 1 }, { "Helena Suková", 3 }, { "Steffi Graf", 4 }, { "Zina Garrison", 2 }, { "Gabriela Sabatini", 1 }, { "Manuela Maleeva", 1 }, { "Arantxa Sánchez", 1 } } },
                { "Mima Jaušovec", new Dictionary<string, int> { { "Virginia Ruzici", 1 } } },
                { "Dianne Fromholtz", new Dictionary<string, int> { { "Zenda Liess", 1 } } },
                { "Wendy Turnbull", new Dictionary<string, int> { { "Martina Navratilova", 1 }, { "Virginia Wade", 1 }, { "Kathy May", 1 }, { "Pam Shriver", 1 } } },
                { "Betty Stöve", new Dictionary<string, int> { { "Tracy Austin", 1 } } },
                { "Pam Shriver", new Dictionary<string, int> { { "Martina Navratilova", 2 }, { "Lesley Hunt", 1 }, { "Andrea Jaeger", 1 } } },
                { "Tracy Austin", new Dictionary<string, int> { { "Chris Evert", 1 }, { "Martina Navratilova", 2 }, { "Sylvia Hanika", 2 }, { "Pam Shriver", 1 }, { "Barbara Potter", 1 } } },
                { "Hana Mandlíková", new Dictionary<string, int> { { "Andrea Jaeger", 1 }, { "Barbara Hallquist", 1 }, { "Pam Shriver", 1 }, { "Tracy Austin", 1 }, { "Martina Navratilova", 1 }, { "Chris Evert", 1 }, { "Helena Suková", 1 } } },
                { "Andrea Jaeger", new Dictionary<string, int> { { "Ivanna Madruga", 1 }, { "Gretchen Rush", 1 } } },
                { "Barbara Potter", new Dictionary<string, int> { { "Barbara Gerken", 1 } } },
                { "Jo Durie", new Dictionary<string, int> { { "Ivanna Madruga", 1 } } },
                { "Carling Bassett", new Dictionary<string, int> { { "Hana Mandlíková", 1 } } },
                { "Steffi Graf", new Dictionary<string, int> { { "Pam Shriver", 2 }, { "Bonnie Gadusek", 1 }, { "Lori McNeil", 1 }, { "Gabriela Sabatini", 4 }, { "Chris Evert", 1 }, { "Katerina Maleeva", 1 }, { "Martina Navratilova", 1 }, { "Helena Suková", 2 }, { "Arantxa Sánchez", 1 }, { "Jana Novotná", 2 }, { "Conchita Martínez", 1 }, { "Manuela Maleeva", 1 }, { "Amanda Coetzer", 1 }, { "Monica Seles", 2 }, { "Amy Frazier", 1 }, { "Martina Hingis", 1 }, { "Judith Wiesner", 1 } } },
                { "Helena Suková", new Dictionary<string, int> { { "Chris Evert", 1 }, { "Wendy Turnbull", 1 }, { "Claudia Kohde-Kilsch", 1 }, { "Arantxa Sánchez", 1 }, { "Katerina Maleeva", 1 } } },
                { "Lori McNeil", new Dictionary<string, int> { { "Chris Evert", 1 } } },
                { "Gabriela Sabatini", new Dictionary<string, int> { { "Zina Garrison", 1 }, { "Larisa Savchenko", 1 }, { "Arantxa Sánchez", 1 }, { "Steffi Graf", 1 }, { "Mary Joe Fernández", 2 }, { "Leila Meskhi", 1 }, { "Gigi Fernández", 1 } } },
                { "Zina Garrison", new Dictionary<string, int> { { "Martina Navratilova", 1 }, { "Chris Evert", 1 } } },
                { "Arantxa Sánchez", new Dictionary<string, int> { { "Zina Garrison", 1 }, { "Manuela Maleeva", 1 }, { "Steffi Graf", 2 }, { "Natasha Zvereva", 1 }, { "Gabriela Sabatini", 1 }, { "Kimiko Date", 1 } } },
                { "Mary Joe Fernández", new Dictionary<string, int> { { "Manuela Maleeva", 1 }, { "Gabriela Sabatini", 1 } } },
                { "Monica Seles", new Dictionary<string, int> { { "Martina Navratilova", 1 }, { "Jennifer Capriati", 1 }, { "Gigi Fernández", 1 }, { "Arantxa Sánchez", 1 }, { "Mary Joe Fernández", 1 }, { "Patricia Hy", 1 }, { "Conchita Martínez", 2 }, { "Jana Novotná", 1 }, { "Amanda Coetzer", 1 } } },
                { "Jennifer Capriati", new Dictionary<string, int> { { "Gabriela Sabatini", 1 }, { "Amélie Mauresmo", 1 }, { "Francesca Schiavone", 1 }, { "Serena Williams", 1 } } },
                { "Manuela Maleeva", new Dictionary<string, int> { { "Magdalena Maleeva", 1 }, { "Kimiko Date", 1 } } },
                { "Jana Novotná", new Dictionary<string, int> { { "Mary Pierce", 1 }, { "Patty Schnyder", 1 } } },
                { "Martina Hingis", new Dictionary<string, int> { { "Jana Novotná", 2 }, { "Venus Williams", 2 }, { "Lindsay Davenport", 1 }, { "Arantxa Sánchez", 1 }, { "Monica Seles", 2 }, { "Anke Huber", 1 }, { "Dája Bedáňová", 1 } } },
                { "Conchita Martínez", new Dictionary<string, int> { { "Linda Wild", 1 } } },
                { "Venus Williams", new Dictionary<string, int> { { "Irina Spîrlea", 1 }, { "Sandrine Testud", 1 }, { "Arantxa Sánchez", 1 }, { "Barbara Schett", 1 }, { "Nathalie Tauziat", 1 }, { "Martina Hingis", 1 }, { "Lindsay Davenport", 1 }, { "Kim Clijsters", 1 }, { "Jennifer Capriati", 1 }, { "Serena Williams", 1 }, { "Monica Seles", 1 }, { "Amélie Mauresmo", 1 }, { "Jelena Janković", 1 }, { "Francesca Schiavone", 1 }, { "Petra Kvitová", 1 } } },
                { "Lindsay Davenport", new Dictionary<string, int> { { "Jana Novotná", 1 }, { "Martina Hingis", 1 }, { "Venus Williams", 1 }, { "Amanda Coetzer", 1 }, { "Mary Pierce", 1 }, { "Serena Williams", 1 }, { "Elena Dementieva", 1 }, { "Elena Bovina", 1 }, { "Paola Suárez", 1 }, { "Shinobu Asagoe", 1 } } },
                { "Irina Spîrlea", new Dictionary<string, int> { { "Monica Seles", 1 } } },
                { "Serena Williams", new Dictionary<string, int> { { "Martina Hingis", 2 }, { "Lindsay Davenport", 3 }, { "Monica Seles", 1 }, { "Daniela Hantuchová", 1 }, { "Venus Williams", 3 }, { "Dinara Safina", 1 }, { "Jelena Janković", 1 }, { "Flavia Pennetta", 2 }, { "Caroline Wozniacki", 2 }, { "Ana Ivanovic", 1 }, { "Sara Errani", 1 }, { "Victoria Azarenka", 2 }, { "Carla Suárez Navarro", 1 }, { "Li Na", 1 }, { "Ekaterina Makarova", 1 }, { "Simona Halep", 1 }, { "Karolína Plíšková", 1 }, { "Anastasija Sevastova", 1 } } },
                { "Elena Dementieva", new Dictionary<string, int> { { "Anke Huber", 1 }, { "Amélie Mauresmo", 1 }, { "Jennifer Capriati", 1 }, { "Lindsay Davenport", 1 }, { "Patty Schnyder", 1 } } },
                { "Amélie Mauresmo", new Dictionary<string, int> { { "Jennifer Capriati", 1 }, { "Dinara Safina", 1 } } },
                { "Kim Clijsters", new Dictionary<string, int> { { "Amélie Mauresmo", 1 }, { "Lindsay Davenport", 1 }, { "Venus Williams", 2 }, { "Maria Sharapova", 1 }, { "Mary Pierce", 1 }, { "Li Na", 1 }, { "Serena Williams", 1 }, { "Caroline Wozniacki", 1 }, { "Samantha Stosur", 1 }, { "Vera Zvonareva", 1 } } },
                { "Justine Henin", new Dictionary<string, int> { { "Anastasia Myskina", 1 }, { "Jennifer Capriati", 1 }, { "Kim Clijsters", 1 }, { "Lindsay Davenport", 1 }, { "Jelena Janković", 1 }, { "Serena Williams", 1 }, { "Venus Williams", 1 }, { "Svetlana Kuznetsova", 1 } } },
                { "Svetlana Kuznetsova", new Dictionary<string, int> { { "Nadia Petrova", 1 }, { "Lindsay Davenport", 1 }, { "Elena Dementieva", 1 }, { "Ágnes Szávay", 1 }, { "Anna Chakvetadze", 1 } } },
                { "Maria Sharapova", new Dictionary<string, int> { { "Nadia Petrova", 1 }, { "Tatiana Golovin", 1 }, { "Amélie Mauresmo", 1 }, { "Justine Henin", 1 }, { "Marion Bartoli", 1 } } },
                { "Mary Pierce", new Dictionary<string, int> { { "Amélie Mauresmo", 1 }, { "Elena Dementieva", 1 } } },
                { "Jelena Janković", new Dictionary<string, int> { { "Elena Dementieva", 2 }, { "Sybille Bammer", 1 } } },
                { "Anna Chakvetadze", new Dictionary<string, int> { { "Shahar Pe’er", 1 } } },
                { "Dinara Safina", new Dictionary<string, int> { { "Flavia Pennetta", 1 } } },
                { "Yanina Wickmayer", new Dictionary<string, int> { { "Kateryna Bondarenko", 1 } } },
                { "Caroline Wozniacki", new Dictionary<string, int> { { "Melanie Oudin", 1 }, { "Yanina Wickmayer", 1 }, { "Dominika Cibulková", 1 }, { "Andrea Petkovic", 1 }, { "Sara Errani", 1 }, { "Peng Shuai", 1 }, { "Anastasija Sevastova", 1 } } },
                { "Vera Zvonareva", new Dictionary<string, int> { { "Kaia Kanepi", 1 }, { "Caroline Wozniacki", 1 } } },
                { "Angelique Kerber", new Dictionary<string, int> { { "Flavia Pennetta", 1 }, { "Roberta Vinci", 1 }, { "Caroline Wozniacki", 1 }, { "Karolína Plíšková", 1 } } },
                { "Samantha Stosur", new Dictionary<string, int> { { "Vera Zvonareva", 1 }, { "Angelique Kerber", 1 }, { "Serena Williams", 1 } } },
                { "Victoria Azarenka", new Dictionary<string, int> { { "Samantha Stosur", 1 }, { "Maria Sharapova", 1 }, { "Daniela Hantuchová", 1 }, { "Flavia Pennetta", 1 } } },
                { "Sara Errani", new Dictionary<string, int> { { "Roberta Vinci", 1 } } },
                { "Li Na", new Dictionary<string, int> { { "Ekaterina Makarova", 1 } } },
                { "Flavia Pennetta", new Dictionary<string, int> { { "Roberta Vinci", 2 }, { "Petra Kvitová", 1 }, { "Simona Halep", 1 } } },
                { "Ekaterina Makarova", new Dictionary<string, int> { { "Victoria Azarenka", 1 } } },
                { "Peng Shuai", new Dictionary<string, int> { { "Belinda Bencic", 1 } } },
                { "Roberta Vinci", new Dictionary<string, int> { { "Kristina Mladenovic", 1 }, { "Serena Williams", 1 } } },
                { "Simona Halep", new Dictionary<string, int> { { "Victoria Azarenka", 1 } } },
                { "Karolína Plíšková", new Dictionary<string, int> { { "Ana Konjuh", 1 }, { "Serena Williams", 1 } } },
                { "CoCo Vandeweghe", new Dictionary<string, int> { { "Karolína Plíšková", 1 } } },
                { "Madison Keys", new Dictionary<string, int> { { "Kaia Kanepi", 1 }, { "CoCo Vandeweghe", 1 }, { "Carla Suárez Navarro", 1 } } },
                { "Sloane Stephens", new Dictionary<string, int> { { "Anastasija Sevastova", 1 }, { "Venus Williams", 1 }, { "Madison Keys", 1 } } },
                { "Anastasija Sevastova", new Dictionary<string, int> { { "Sloane Stephens", 1 } } },
                { "Naomi Osaka", new Dictionary<string, int> { { "Lesia Tsurenko", 1 }, { "Madison Keys", 1 }, { "Serena Williams", 1 } } }
            };
        }
        
        static Dictionary<string, Dictionary<string, int>> frenchOpenMens()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "Ken Rosewall", new Dictionary<string, int> { { "Thomaz Koch", 1 }, { "Andrés Gimeno", 1 }, { "Rod Laver", 1 }, { "Tony Roche", 1 }, { "Fred Stolle", 1 } } },
                { "Andrés Gimeno", new Dictionary<string, int> { { "Boro Jovanović", 1 }, { "Patrick Proisy", 1 }, { "Alex Metreveli", 1 }, { "Stan Smith", 1 } } },
                { "Pancho Gonzales", new Dictionary<string, int> { { "Roy Emerson", 1 } } },
                { "Rod Laver", new Dictionary<string, int> { { "Ion Țiriac", 1 }, { "Pancho Gonzales", 1 }, { "Ken Rosewall", 1 }, { "Tom Okker", 1 }, { "Andrés Gimeno", 1 } } },
                { "Tony Roche", new Dictionary<string, int> { { "Željko Franulović", 1 } } },
                { "Tom Okker", new Dictionary<string, int> { { "John Newcombe", 1 } } },
                { "Jan Kodeš", new Dictionary<string, int> { { "Željko Franulović", 2 }, { "Georges Goven", 1 }, { "Martin Mulligan", 1 }, { "Ilie Năstase", 1 }, { "Patrick Proisy", 1 } } },
                { "Željko Franulović", new Dictionary<string, int> { { "Cliff Richey", 1 }, { "Arthur Ashe", 1 }, { "István Gulyás", 1 } } },
                { "Georges Goven", new Dictionary<string, int> { { "François Jauffret", 1 } } },
                { "Cliff Richey", new Dictionary<string, int> { { "Ilie Năstase", 1 } } },
                { "Ilie Năstase", new Dictionary<string, int> { { "Frank Froehling", 1 }, { "Stan Smith", 1 }, { "Nikola Pilić", 1 }, { "Tom Gorman", 1 }, { "Roger Taylor", 1 } } },
                { "Frank Froehling", new Dictionary<string, int> { { "Arthur Ashe", 1 } } },
                { "Patrick Proisy", new Dictionary<string, int> { { "Manuel Orantes", 1 }, { "Jan Kodeš", 1 } } },
                { "Alex Metreveli", new Dictionary<string, int> { { "Adriano Panatta", 1 } } },
                { "Manuel Orantes", new Dictionary<string, int> { { "Harold Solomon", 1 }, { "François Jauffret", 1 }, { "Patricio Cornejo", 1 } } },
                { "Nikola Pilić", new Dictionary<string, int> { { "Adriano Panatta", 1 }, { "Paolo Bertolucci", 1 } } },
                { "Tom Gorman", new Dictionary<string, int> { { "Jan Kodeš", 1 } } },
                { "Adriano Panatta", new Dictionary<string, int> { { "Tom Okker", 1 }, { "John Andrews", 1 }, { "Harold Solomon", 1 }, { "Eddie Dibbs", 1 }, { "Björn Borg", 1 } } },
                { "Björn Borg", new Dictionary<string, int> { { "Manuel Orantes", 1 }, { "Harold Solomon", 3 }, { "Raúl Ramírez", 2 }, { "Guillermo Vilas", 2 }, { "Adriano Panatta", 1 }, { "Corrado Barazzutti", 2 }, { "Víctor Pecci", 2 }, { "Vitas Gerulaitis", 2 }, { "Hans Gildemeister", 1 }, { "Ivan Lendl", 1 }, { "Balázs Taróczy", 1 } } },
                { "Harold Solomon", new Dictionary<string, int> { { "Ilie Năstase", 1 }, { "Raúl Ramírez", 1 }, { "Guillermo Vilas", 2 } } },
                { "Guillermo Vilas", new Dictionary<string, int> { { "Eddie Dibbs", 1 }, { "Onny Parun", 1 }, { "Brian Gottfried", 1 }, { "Raúl Ramírez", 1 }, { "Wojciech Fibak", 1 }, { "Dick Stockton", 1 }, { "Hans Gildemeister", 1 }, { "José Higueras", 1 }, { "Yannick Noah", 1 } } },
                { "Eddie Dibbs", new Dictionary<string, int> { { "Raúl Ramírez", 1 }, { "Manuel Orantes", 1 } } },
                { "Raúl Ramírez", new Dictionary<string, int> { { "Balázs Taróczy", 1 }, { "Adriano Panatta", 1 } } },
                { "Brian Gottfried", new Dictionary<string, int> { { "Phil Dent", 1 }, { "Ilie Năstase", 1 } } },
                { "Phil Dent", new Dictionary<string, int> { { "José Higueras", 1 } } },
                { "Corrado Barazzutti", new Dictionary<string, int> { { "Eddie Dibbs", 1 } } },
                { "Dick Stockton", new Dictionary<string, int> { { "Manuel Orantes", 1 } } },
                { "Víctor Pecci", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Guillermo Vilas", 1 }, { "Yannick Noah", 1 } } },
                { "Vitas Gerulaitis", new Dictionary<string, int> { { "José Higueras", 1 }, { "Jimmy Connors", 1 }, { "Wojciech Fibak", 1 } } },
                { "Jimmy Connors", new Dictionary<string, int> { { "Eddie Dibbs", 1 }, { "Hans Gildemeister", 1 }, { "Henrik Sundström", 1 }, { "Stefan Edberg", 1 } } },
                { "Ivan Lendl", new Dictionary<string, int> { { "José Luis Clerc", 1 }, { "John McEnroe", 2 }, { "Mats Wilander", 2 }, { "Andrés Gómez", 3 }, { "Jimmy Connors", 1 }, { "Martín Jaite", 1 }, { "Mikael Pernfors", 1 }, { "Johan Kriek", 1 }, { "Miloslav Mečíř", 1 } } },
                { "José Luis Clerc", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Peter McNamara", 1 } } },
                { "Mats Wilander", new Dictionary<string, int> { { "Guillermo Vilas", 1 }, { "José Luis Clerc", 1 }, { "Vitas Gerulaitis", 1 }, { "José Higueras", 1 }, { "John McEnroe", 2 }, { "Yannick Noah", 2 }, { "Ivan Lendl", 1 }, { "Henri Leconte", 2 }, { "Boris Becker", 1 }, { "Andre Agassi", 1 }, { "Emilio Sánchez", 1 } } },
                { "José Higueras", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Guillermo Vilas", 1 } } },
                { "Yannick Noah", new Dictionary<string, int> { { "Mats Wilander", 1 }, { "Ivan Lendl", 1 } } },
                { "John McEnroe", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Jimmy Arias", 1 }, { "Joakim Nyström", 1 } } },
                { "Mikael Pernfors", new Dictionary<string, int> { { "Henri Leconte", 1 }, { "Boris Becker", 1 } } },
                { "Johan Kriek", new Dictionary<string, int> { { "Guillermo Vilas", 1 } } },
                { "Henri Leconte", new Dictionary<string, int> { { "Andrei Chesnokov", 2 }, { "Jonas Svensson", 1 }, { "Nicklas Kulti", 1 } } },
                { "Miloslav Mečíř", new Dictionary<string, int> { { "Karel Nováček", 1 } } },
                { "Boris Becker", new Dictionary<string, int> { { "Jimmy Connors", 1 }, { "Jay Berger", 1 }, { "Michael Chang", 1 } } },
                { "Jonas Svensson", new Dictionary<string, int> { { "Ivan Lendl", 1 }, { "Henri Leconte", 1 } } },
                { "Andre Agassi", new Dictionary<string, int> { { "Guillermo Pérez Roldán", 1 }, { "Jonas Svensson", 1 }, { "Michael Chang", 1 }, { "Boris Becker", 1 }, { "Jakob Hlasek", 1 }, { "Pete Sampras", 1 }, { "Andriy Medvedev", 1 }, { "Dominik Hrbatý", 1 }, { "Marcelo Filippini", 1 } } },
                { "Michael Chang", new Dictionary<string, int> { { "Stefan Edberg", 1 }, { "Andrei Chesnokov", 1 }, { "Ronald Agénor", 1 }, { "Sergi Bruguera", 1 }, { "Adrian Voinea", 1 } } },
                { "Stefan Edberg", new Dictionary<string, int> { { "Boris Becker", 1 }, { "Alberto Mancini", 1 } } },
                { "Andrei Chesnokov", new Dictionary<string, int> { { "Mats Wilander", 1 } } },
                { "Andrés Gómez", new Dictionary<string, int> { { "Andre Agassi", 1 }, { "Thomas Muster", 1 }, { "Thierry Champion", 1 } } },
                { "Thomas Muster", new Dictionary<string, int> { { "Goran Ivanišević", 1 }, { "Michael Chang", 1 }, { "Yevgeny Kafelnikov", 1 }, { "Albert Costa", 1 } } },
                { "Jim Courier", new Dictionary<string, int> { { "Andre Agassi", 2 }, { "Michael Stich", 1 }, { "Stefan Edberg", 1 }, { "Petr Korda", 1 }, { "Goran Ivanišević", 1 }, { "Richard Krajicek", 1 }, { "Goran Prpić", 1 }, { "Pete Sampras", 1 } } },
                { "Michael Stich", new Dictionary<string, int> { { "Franco Davín", 1 }, { "Marc Rosset", 1 }, { "Cédric Pioline", 1 } } },
                { "Petr Korda", new Dictionary<string, int> { { "Henri Leconte", 1 }, { "Andrei Cherkasov", 1 } } },
                { "Sergi Bruguera", new Dictionary<string, int> { { "Jim Courier", 2 }, { "Andrei Medvedev", 2 }, { "Pete Sampras", 1 }, { "Alberto Berasategui", 1 }, { "Renzo Furlan", 1 }, { "Patrick Rafter", 1 }, { "Hicham Arazi", 1 } } },
                { "Andrei Medvedev", new Dictionary<string, int> { { "Stefan Edberg", 1 } } },
                { "Richard Krajicek", new Dictionary<string, int> { { "Karel Nováček", 1 } } },
                { "Alberto Berasategui", new Dictionary<string, int> { { "Magnus Larsson", 1 }, { "Goran Ivanišević", 1 } } },
                { "Magnus Larsson", new Dictionary<string, int> { { "Hendrik Dreekmann", 1 } } },
                { "Yevgeny Kafelnikov", new Dictionary<string, int> { { "Andre Agassi", 1 }, { "Michael Stich", 1 }, { "Pete Sampras", 1 }, { "Richard Krajicek", 1 } } },
                { "Pete Sampras", new Dictionary<string, int> { { "Jim Courier", 1 } } },
                { "Marc Rosset", new Dictionary<string, int> { { "Bernd Karbacher", 1 } } },
                { "Gustavo Kuerten", new Dictionary<string, int> { { "Sergi Bruguera", 1 }, { "Filip Dewulf", 1 }, { "Yevgeny Kafelnikov", 3 }, { "Magnus Norman", 1 }, { "Juan Carlos Ferrero", 2 }, { "Àlex Corretja", 1 } } },
                { "Filip Dewulf", new Dictionary<string, int> { { "Magnus Norman", 1 } } },
                { "Patrick Rafter", new Dictionary<string, int> { { "Galo Blanco", 1 } } },
                { "Carlos Moyà", new Dictionary<string, int> { { "Àlex Corretja", 1 }, { "Félix Mantilla Botella", 1 }, { "Marcelo Ríos", 1 } } },
                { "Àlex Corretja", new Dictionary<string, int> { { "Cédric Pioline", 1 }, { "Filip Dewulf", 1 }, { "Sébastien Grosjean", 1 }, { "Roger Federer", 1 }, { "Andrei Pavel", 1 } } },
                { "Félix Mantilla Botella", new Dictionary<string, int> { { "Thomas Muster", 1 } } },
                { "Cédric Pioline", new Dictionary<string, int> { { "Hicham Arazi", 1 } } },
                { "Andriy Medvedev", new Dictionary<string, int> { { "Fernando Meligeni", 1 }, { "Gustavo Kuerten", 1 } } },
                { "Dominik Hrbatý", new Dictionary<string, int> { { "Marcelo Ríos", 1 } } },
                { "Fernando Meligeni", new Dictionary<string, int> { { "Àlex Corretja", 1 } } },
                { "Magnus Norman", new Dictionary<string, int> { { "Franco Squillari", 1 }, { "Marat Safin", 1 } } },
                { "Franco Squillari", new Dictionary<string, int> { { "Albert Costa", 1 } } },
                { "Juan Carlos Ferrero", new Dictionary<string, int> { { "Àlex Corretja", 1 }, { "Lleyton Hewitt", 1 }, { "Marat Safin", 1 }, { "Andre Agassi", 1 }, { "Martin Verkerk", 1 }, { "Albert Costa", 1 }, { "Fernando González", 1 } } },
                { "Sébastien Grosjean", new Dictionary<string, int> { { "Andre Agassi", 1 } } },
                { "Albert Costa", new Dictionary<string, int> { { "Juan Carlos Ferrero", 1 }, { "Àlex Corretja", 1 }, { "Guillermo Cañas", 1 }, { "Tommy Robredo", 1 } } },
                { "Marat Safin", new Dictionary<string, int> { { "Sébastien Grosjean", 1 } } },
                { "Martin Verkerk", new Dictionary<string, int> { { "Guillermo Coria", 1 }, { "Carlos Moyà", 1 } } },
                { "Guillermo Coria", new Dictionary<string, int> { { "Andre Agassi", 1 }, { "Carlos Moyà", 1 }, { "Tim Henman", 1 } } },
                { "David Nalbandian", new Dictionary<string, int> { { "Gustavo Kuerten", 1 }, { "Nikolay Davydenko", 1 } } },
                { "Gastón Gaudio", new Dictionary<string, int> { { "Lleyton Hewitt", 1 }, { "David Nalbandian", 1 }, { "Guillermo Coria", 1 } } },
                { "Tim Henman", new Dictionary<string, int> { { "Juan Ignacio Chela", 1 } } },
                { "Roger Federer", new Dictionary<string, int> { { "Victor Hănescu", 1 }, { "Mario Ančić", 1 }, { "David Nalbandian", 1 }, { "Tommy Robredo", 1 }, { "Nikolay Davydenko", 1 }, { "Fernando González", 1 }, { "Gaël Monfils", 3 }, { "Juan Martín del Potro", 2 }, { "Robin Söderling", 1 }, { "Novak Djokovic", 1 } } },
                { "Rafael Nadal", new Dictionary<string, int> { { "David Ferrer", 4 }, { "Roger Federer", 5 }, { "Mariano Puerta", 1 }, { "Novak Djokovic", 6 }, { "Ivan Ljubičić", 1 }, { "Carlos Moyà", 1 }, { "Nicolás Almagro", 3 }, { "Jürgen Melzer", 1 }, { "Robin Söderling", 2 }, { "Andy Murray", 2 }, { "Stanislas Wawrinka", 1 }, { "Pablo Carreño Busta", 1 }, { "Dominic Thiem", 2 }, { "Stan Wawrinka", 1 }, { "Diego Schwartzman", 1 }, { "Juan Martín del Potro", 1 } } },
                { "Nikolay Davydenko", new Dictionary<string, int> { { "Tommy Robredo", 1 }, { "Guillermo Cañas", 1 } } },
                { "Mariano Puerta", new Dictionary<string, int> { { "Guillermo Cañas", 1 }, { "Nikolay Davydenko", 1 } } },
                { "Ivan Ljubičić", new Dictionary<string, int> { { "Julien Benneteau", 1 } } },
                { "Novak Djokovic", new Dictionary<string, int> { { "Igor Andreev", 1 }, { "Ernests Gulbis", 2 }, { "Fabio Fognini", 1 }, { "Jo-Wilfried Tsonga", 1 }, { "Roger Federer", 1 }, { "Tommy Haas", 1 }, { "Milos Raonic", 1 }, { "Rafael Nadal", 1 }, { "Andy Murray", 2 }, { "Tomáš Berdych", 1 }, { "Dominic Thiem", 1 } } },
                { "Gaël Monfils", new Dictionary<string, int> { { "David Ferrer", 1 } } },
                { "Robin Söderling", new Dictionary<string, int> { { "Nikolay Davydenko", 1 }, { "Fernando González", 1 }, { "Roger Federer", 1 }, { "Tomáš Berdych", 1 } } },
                { "Fernando González", new Dictionary<string, int> { { "Andy Murray", 1 } } },
                { "Juan Martín del Potro", new Dictionary<string, int> { { "Tommy Robredo", 1 }, { "Marin Čilić", 1 } } },
                { "Tomáš Berdych", new Dictionary<string, int> { { "Mikhail Youzhny", 1 } } },
                { "Jürgen Melzer", new Dictionary<string, int> { { "Novak Djokovic", 1 } } },
                { "Andy Murray", new Dictionary<string, int> { { "Juan Ignacio Chela", 1 }, { "Gaël Monfils", 1 }, { "David Ferrer", 1 }, { "Richard Gasquet", 1 }, { "Stan Wawrinka", 1 }, { "Kei Nishikori", 1 } } },
                { "David Ferrer", new Dictionary<string, int> { { "Andy Murray", 1 }, { "Tommy Robredo", 1 }, { "Jo-Wilfried Tsonga", 1 } } },
                { "Jo-Wilfried Tsonga", new Dictionary<string, int> { { "Roger Federer", 1 }, { "Kei Nishikori", 1 } } },
                { "Ernests Gulbis", new Dictionary<string, int> { { "Tomáš Berdych", 1 } } },
                { "Stan Wawrinka", new Dictionary<string, int> { { "Roger Federer", 1 }, { "Jo-Wilfried Tsonga", 1 }, { "Novak Djokovic", 1 }, { "Albert Ramos-Viñolas", 1 }, { "Marin Čilić", 1 }, { "Andy Murray", 1 } } },
                { "Dominic Thiem", new Dictionary<string, int> { { "David Goffin", 1 }, { "Novak Djokovic", 1 }, { "Alexander Zverev", 1 }, { "Marco Cecchinato", 1 } } },
                { "Marco Cecchinato", new Dictionary<string, int> { { "Novak Djokovic", 1 } } }
            };
        }
        
        static Dictionary<string, Dictionary<string, int>> frenchOpenWomens()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "Ann Jones", new Dictionary<string, int> { { "Vlasta Vopičková", 1 }, { "Annette Van Zyl", 1 } } },
                { "Annette Van Zyl", new Dictionary<string, int> { { "Gail Chanfreau", 1 } } },
                { "Nancy Richey", new Dictionary<string, int> { { "Elena Subirats", 1 }, { "Billie Jean King", 1 }, { "Ann Jones", 1 }, { "Julie Heldman", 1 }, { "Lesley Bowrey", 1 } } },
                { "Billie Jean King", new Dictionary<string, int> { { "Maria Bueno", 1 }, { "Evonne Goolagong", 1 }, { "Helga Niessen", 1 }, { "Virginia Wade", 1 } } },
                { "Margaret Court", new Dictionary<string, int> { { "Ann Haydon-Jones", 1 }, { "Nancy Richey", 1 }, { "Kerry Reid", 1 }, { "Helga Niessen", 1 }, { "Julie Heldman", 1 }, { "Rosemary Casals", 1 }, { "Chris Evert", 1 }, { "Evonne Goolagong", 1 }, { "Katja Ebbinghaus", 1 } } },
                { "Ann Haydon-Jones", new Dictionary<string, int> { { "Lesley Bowrey", 1 }, { "Rosemary Casals", 1 } } },
                { "Lesley Bowrey", new Dictionary<string, int> { { "Billie Jean King", 1 } } },
                { "Helga Niessen", new Dictionary<string, int> { { "Karen Krantzcke", 1 }, { "Billie Jean King", 1 }, { "Katja Ebbinghaus", 1 } } },
                { "Julie Heldman", new Dictionary<string, int> { { "Vlasta Vopičková", 1 } } },
                { "Karen Krantzcke", new Dictionary<string, int> { { "Virginia Wade", 1 } } },
                { "Evonne Goolagong", new Dictionary<string, int> { { "Helen Gourlay", 1 }, { "Marijke Schaar", 1 }, { "Françoise Dürr", 2 }, { "Corinne Molesworth", 1 }, { "Martina Navratilova", 1 } } },
                { "Helen Gourlay", new Dictionary<string, int> { { "Nancy Richey", 1 }, { "Gail Chanfreau", 1 } } },
                { "Marijke Schaar", new Dictionary<string, int> { { "Linda Tuero", 1 } } },
                { "Françoise Dürr", new Dictionary<string, int> { { "Olga Morozova", 1 }, { "Odile de Roubin", 1 } } },
                { "Chris Evert", new Dictionary<string, int> { { "Françoise Dürr", 1 }, { "Helga Masthoff", 2 }, { "Olga Morozova", 2 }, { "Julie Heldman", 1 }, { "Martina Navratilova", 3 }, { "Kazuko Sawamatsu", 1 }, { "Wendy Turnbull", 1 }, { "Dianne Fromholtz", 1 }, { "Ruta Gerulaitis", 1 }, { "Virginia Ruzici", 2 }, { "Hana Mandlíková", 3 }, { "Kathy Jordan", 1 }, { "Lucia Romanov", 1 }, { "Andrea Jaeger", 1 }, { "Mima Jaušovec", 1 }, { "Camille Benjamin", 1 }, { "Carling Bassett", 2 }, { "Gabriela Sabatini", 1 }, { "Terry Phelps", 1 }, { "Raffaella Reggi", 1 } } },
                { "Olga Morozova", new Dictionary<string, int> { { "Raquel Giscafré", 2 }, { "Marie Pinterova", 1 } } },
                { "Helga Masthoff", new Dictionary<string, int> { { "Martina Navratilova", 1 } } },
                { "Raquel Giscafré", new Dictionary<string, int> { { "Katja Ebbinghaus", 1 } } },
                { "Martina Navratilova", new Dictionary<string, int> { { "Janet Newberry", 1 }, { "Donna Ganz", 1 }, { "Andrea Jaeger", 1 }, { "Hana Mandlíková", 2 }, { "Zina Garrison", 1 }, { "Chris Evert", 2 }, { "Kathy Horvath", 1 }, { "Claudia Kohde-Kilsch", 2 }, { "Sandra Cecchini", 1 }, { "Helena Suková", 1 }, { "Kathy Rinaldi", 1 } } },
                { "Janet Newberry", new Dictionary<string, int> { { "Éva Szabó", 1 }, { "Kathy May", 1 } } },
                { "Sue Barker", new Dictionary<string, int> { { "Renáta Tomanová", 1 }, { "Virginia Ruzici", 1 }, { "Regina Maršíková", 1 } } },
                { "Renáta Tomanová", new Dictionary<string, int> { { "Florența Mihai", 1 }, { "Helga Masthoff", 1 } } },
                { "Florența Mihai", new Dictionary<string, int> { { "Kathy Kuykendall", 1 }, { "Janet Newberry", 1 }, { "Linky Boshoff", 1 } } },
                { "Virginia Ruzici", new Dictionary<string, int> { { "Miroslava Holubova", 1 }, { "Mima Jaušovec", 1 }, { "Brigitte Simon", 1 }, { "Fiorella Bonicelli", 1 }, { "Dianne Fromholtz", 1 }, { "Wendy Turnbull", 1 } } },
                { "Mima Jaušovec", new Dictionary<string, int> { { "Florența Mihai", 1 }, { "Regina Maršíková", 2 }, { "Pam Teeguarden", 1 }, { "Kathy May", 1 }, { "Kathy Horvath", 1 }, { "Jo Durie", 1 } } },
                { "Regina Maršíková", new Dictionary<string, int> { { "Renáta Tomanová", 2 }, { "Helga Masthoff", 1 } } },
                { "Brigitte Simon", new Dictionary<string, int> { { "Miroslava Bendlova", 1 } } },
                { "Wendy Turnbull", new Dictionary<string, int> { { "Regina Maršíková", 1 }, { "Hana Mandlíková", 1 } } },
                { "Dianne Fromholtz", new Dictionary<string, int> { { "Virginia Ruzici", 1 }, { "Billie Jean King", 1 } } },
                { "Hana Mandlíková", new Dictionary<string, int> { { "Ivanna Madruga", 1 }, { "Sylvia Hanika", 1 }, { "Chris Evert", 1 }, { "Kathy Rinaldi", 1 }, { "Tracy Austin", 1 }, { "Melissa Brown", 1 }, { "Steffi Graf", 1 } } },
                { "Sylvia Hanika", new Dictionary<string, int> { { "Andrea Jaeger", 1 }, { "Martina Navratilova", 1 } } },
                { "Andrea Jaeger", new Dictionary<string, int> { { "Mima Jaušovec", 1 }, { "Chris Evert", 1 }, { "Virginia Ruzici", 1 }, { "Gretchen Rush", 1 } } },
                { "Jo Durie", new Dictionary<string, int> { { "Tracy Austin", 1 } } },
                { "Camille Benjamin", new Dictionary<string, int> { { "Lisa Bonder", 1 } } },
                { "Claudia Kohde-Kilsch", new Dictionary<string, int> { { "Hana Mandlíková", 1 } } },
                { "Gabriela Sabatini", new Dictionary<string, int> { { "Manuela Maleeva", 1 }, { "Arantxa Sánchez", 1 }, { "Helen Kelesi", 1 }, { "Jana Novotná", 1 }, { "Conchita Martínez", 1 } } },
                { "Helena Suková", new Dictionary<string, int> { { "Mary Joe Fernández", 1 } } },
                { "Steffi Graf", new Dictionary<string, int> { { "Martina Navratilova", 1 }, { "Gabriela Sabatini", 3 }, { "Manuela Maleeva", 1 }, { "Natasha Zvereva", 2 }, { "Bettina Fulco", 1 }, { "Monica Seles", 2 }, { "Conchita Martínez", 4 }, { "Jana Novotná", 1 }, { "Nathalie Tauziat", 1 }, { "Arantxa Sánchez", 3 }, { "Mary Joe Fernández", 1 }, { "Anke Huber", 1 }, { "Jennifer Capriati", 1 }, { "Inés Gorrochategui", 1 }, { "Iva Majoli", 1 }, { "Martina Hingis", 1 }, { "Lindsay Davenport", 1 } } },
                { "Natasha Zvereva", new Dictionary<string, int> { { "Nicole Provis", 1 }, { "Helena Suková", 1 } } },
                { "Nicole Provis", new Dictionary<string, int> { { "Arantxa Sánchez", 1 } } },
                { "Arantxa Sánchez", new Dictionary<string, int> { { "Steffi Graf", 2 }, { "Mary Joe Fernández", 2 }, { "Jana Novotná", 3 }, { "Manon Bollegraf", 1 }, { "Mary Pierce", 1 }, { "Conchita Martínez", 1 }, { "Julie Halard", 1 }, { "Kimiko Date", 1 }, { "Chanda Rubin", 1 }, { "Karina Habšudová", 1 }, { "Monica Seles", 1 }, { "Lindsay Davenport", 1 }, { "Patty Schnyder", 1 }, { "Sylvia Plischke", 1 }, { "Venus Williams", 1 } } },
                { "Monica Seles", new Dictionary<string, int> { { "Manuela Maleeva", 2 }, { "Steffi Graf", 2 }, { "Jennifer Capriati", 2 }, { "Arantxa Sánchez", 1 }, { "Gabriela Sabatini", 2 }, { "Conchita Martínez", 2 }, { "Mary Joe Fernández", 1 }, { "Martina Hingis", 1 }, { "Jana Novotná", 1 } } },
                { "Mary Joe Fernández", new Dictionary<string, int> { { "Helen Kelesi", 1 }, { "Arantxa Sánchez", 1 }, { "Gabriela Sabatini", 1 } } },
                { "Jana Novotná", new Dictionary<string, int> { { "Katerina Maleeva", 1 }, { "Monica Seles", 1 } } },
                { "Jennifer Capriati", new Dictionary<string, int> { { "Mary Joe Fernández", 1 }, { "Kim Clijsters", 1 }, { "Martina Hingis", 1 }, { "Serena Williams", 2 }, { "Jelena Dokić", 1 } } },
                { "Anke Huber", new Dictionary<string, int> { { "Conchita Martínez", 1 } } },
                { "Mary Pierce", new Dictionary<string, int> { { "Steffi Graf", 1 }, { "Petra Ritter", 1 }, { "Conchita Martínez", 1 }, { "Martina Hingis", 1 }, { "Monica Seles", 1 }, { "Lindsay Davenport", 1 }, { "Elena Likhovtseva", 1 } } },
                { "Conchita Martínez", new Dictionary<string, int> { { "Sabine Hack", 1 }, { "Virginia Ruano Pascual", 1 }, { "Lindsay Davenport", 1 }, { "Arantxa Sánchez", 1 }, { "Marta Marrero", 1 } } },
                { "Kimiko Date", new Dictionary<string, int> { { "Iva Majoli", 1 } } },
                { "Iva Majoli", new Dictionary<string, int> { { "Martina Hingis", 1 }, { "Amanda Coetzer", 1 }, { "Ruxandra Dragomir", 1 } } },
                { "Martina Hingis", new Dictionary<string, int> { { "Monica Seles", 1 }, { "Arantxa Sánchez", 2 }, { "Venus Williams", 1 }, { "Barbara Schwartz", 1 }, { "Chanda Rubin", 1 }, { "Francesca Schiavone", 1 } } },
                { "Amanda Coetzer", new Dictionary<string, int> { { "Steffi Graf", 1 } } },
                { "Lindsay Davenport", new Dictionary<string, int> { { "Iva Majoli", 1 } } },
                { "Kim Clijsters", new Dictionary<string, int> { { "Justine Henin", 1 }, { "Petra Mandula", 1 }, { "Nadia Petrova", 1 }, { "Conchita Martínez", 1 }, { "Martina Hingis", 1 } } },
                { "Serena Williams", new Dictionary<string, int> { { "Venus Williams", 1 }, { "Jennifer Capriati", 1 }, { "Mary Pierce", 1 }, { "Amélie Mauresmo", 1 }, { "Svetlana Kuznetsova", 1 }, { "Sara Errani", 2 }, { "Maria Sharapova", 1 }, { "Timea Bacsinszky", 1 }, { "Lucie Šafářová", 1 }, { "Yulia Putintseva", 1 }, { "Kiki Bertens", 1 } } },
                { "Venus Williams", new Dictionary<string, int> { { "Clarisa Fernández", 1 }, { "Monica Seles", 1 } } },
                { "Clarisa Fernández", new Dictionary<string, int> { { "Paola Suárez", 1 } } },
                { "Justine Henin", new Dictionary<string, int> { { "Kim Clijsters", 2 }, { "Serena Williams", 2 }, { "Chanda Rubin", 1 }, { "Maria Sharapova", 1 }, { "Nadia Petrova", 1 }, { "Mary Pierce", 1 }, { "Anna-Lena Grönefeld", 1 }, { "Svetlana Kuznetsova", 1 }, { "Jelena Janković", 1 }, { "Ana Ivanovic", 1 } } },
                { "Nadia Petrova", new Dictionary<string, int> { { "Vera Zvonareva", 1 }, { "Ana Ivanovic", 1 } } },
                { "Anastasia Myskina", new Dictionary<string, int> { { "Elena Dementieva", 1 }, { "Jennifer Capriati", 1 }, { "Venus Williams", 1 } } },
                { "Elena Dementieva", new Dictionary<string, int> { { "Paola Suárez", 1 }, { "Amélie Mauresmo", 1 }, { "Nadia Petrova", 1 } } },
                { "Paola Suárez", new Dictionary<string, int> { { "Maria Sharapova", 1 } } },
                { "Elena Likhovtseva", new Dictionary<string, int> { { "Sesil Karatantcheva", 1 } } },
                { "Nicole Vaidišová", new Dictionary<string, int> { { "Venus Williams", 1 } } },
                { "Svetlana Kuznetsova", new Dictionary<string, int> { { "Dinara Safina", 2 }, { "Nicole Vaidišová", 1 }, { "Kaia Kanepi", 1 }, { "Serena Williams", 1 }, { "Samantha Stosur", 1 } } },
                { "Jelena Janković", new Dictionary<string, int> { { "Nicole Vaidišová", 1 }, { "Carla Suárez Navarro", 1 }, { "Yaroslava Shvedova", 1 } } },
                { "Ana Ivanovic", new Dictionary<string, int> { { "Svetlana Kuznetsova", 1 }, { "Maria Sharapova", 1 }, { "Patty Schnyder", 1 }, { "Jelena Janković", 1 }, { "Dinara Safina", 1 }, { "Elina Svitolina", 1 } } },
                { "Maria Sharapova", new Dictionary<string, int> { { "Anna Chakvetadze", 1 }, { "Andrea Petkovic", 1 }, { "Kaia Kanepi", 1 }, { "Petra Kvitová", 1 }, { "Sara Errani", 1 }, { "Jelena Janković", 1 }, { "Victoria Azarenka", 1 }, { "Garbiñe Muguruza", 1 }, { "Eugenie Bouchard", 1 }, { "Simona Halep", 1 } } },
                { "Dinara Safina", new Dictionary<string, int> { { "Elena Dementieva", 1 }, { "Svetlana Kuznetsova", 1 }, { "Victoria Azarenka", 1 }, { "Dominika Cibulková", 1 } } },
                { "Dominika Cibulková", new Dictionary<string, int> { { "Maria Sharapova", 1 } } },
                { "Samantha Stosur", new Dictionary<string, int> { { "Sorana Cîrstea", 1 }, { "Serena Williams", 1 }, { "Jelena Janković", 1 }, { "Dominika Cibulková", 1 }, { "Tsvetana Pironkova", 1 } } },
                { "Francesca Schiavone", new Dictionary<string, int> { { "Caroline Wozniacki", 1 }, { "Elena Dementieva", 1 }, { "Samantha Stosur", 1 }, { "Marion Bartoli", 1 } } },
                { "Marion Bartoli", new Dictionary<string, int> { { "Svetlana Kuznetsova", 1 } } },
                { "Li Na", new Dictionary<string, int> { { "Victoria Azarenka", 1 }, { "Maria Sharapova", 1 }, { "Francesca Schiavone", 1 } } },
                { "Sara Errani", new Dictionary<string, int> { { "Angelique Kerber", 1 }, { "Samantha Stosur", 1 }, { "Agnieszka Radwańska", 1 } } },
                { "Petra Kvitová", new Dictionary<string, int> { { "Yaroslava Shvedova", 1 } } },
                { "Victoria Azarenka", new Dictionary<string, int> { { "Maria Kirilenko", 1 } } },
                { "Eugenie Bouchard", new Dictionary<string, int> { { "Carla Suárez Navarro", 1 } } },
                { "Simona Halep", new Dictionary<string, int> { { "Svetlana Kuznetsova", 1 }, { "Andrea Petkovic", 1 }, { "Elina Svitolina", 1 }, { "Karolína Plíšková", 1 }, { "Angelique Kerber", 1 }, { "Garbiñe Muguruza", 1 }, { "Sloane Stephens", 1 } } },
                { "Andrea Petkovic", new Dictionary<string, int> { { "Sara Errani", 1 } } },
                { "Timea Bacsinszky", new Dictionary<string, int> { { "Alison Van Uytvanck", 1 }, { "Kristina Mladenovic", 1 } } },
                { "Lucie Šafářová", new Dictionary<string, int> { { "Garbiñe Muguruza", 1 }, { "Ana Ivanovic", 1 } } },
                { "Kiki Bertens", new Dictionary<string, int> { { "Timea Bacsinszky", 1 } } },
                { "Garbiñe Muguruza", new Dictionary<string, int> { { "Shelby Rogers", 1 }, { "Samantha Stosur", 1 }, { "Serena Williams", 1 }, { "Maria Sharapova", 1 } } },
                { "Jeļena Ostapenko", new Dictionary<string, int> { { "Caroline Wozniacki", 1 }, { "Timea Bacsinszky", 1 }, { "Simona Halep", 1 } } },
                { "Karolína Plíšková", new Dictionary<string, int> { { "Caroline Garcia", 1 } } },
                { "Madison Keys", new Dictionary<string, int> { { "Yulia Putintseva", 1 } } },
                { "Sloane Stephens", new Dictionary<string, int> { { "Daria Kasatkina", 1 }, { "Madison Keys", 1 } } }
            };
        }
        
        // End auto-generated
    }
}
