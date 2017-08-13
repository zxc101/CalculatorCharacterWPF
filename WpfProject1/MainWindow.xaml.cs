using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace WpfProject1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

            TextBlock text = new TextBlock();
            text.FontSize = 30;
            text.Text = "VS";
            VSButton.Content = text;
        }

        private void Fight(Object sender, RoutedEventArgs e)
        {
            int _startlimitMatches = 0;
            countMatchesIsNotNumber.Visibility = Visibility.Hidden;
            countMatchesLessOne.Visibility = Visibility.Hidden;

            int _countMatches;

            if (!int.TryParse(countMatches.Text, out _countMatches) && countMatches.Text != "")
            {
                countMatchesIsNotNumber.Visibility = Visibility.Visible;
                return;
            }

            if (countMatches.Text == "")
            {
                _countMatches = 1;
            }

            if (_countMatches < 1)
            {
                countMatchesLessOne.Visibility = Visibility.Visible;
                return;
            }

            if (!Analysis())
            {
                return;
            }

            Person[] persons = new Person[6];

            persons[0] = new Person(herosAttack.Text,
                                     herosLife.Text,
                                     herosCriticalAttack.Text,
                                     herosAttackPercent.Text,
                                     herosCriticalAttackPercent.Text,
                                     herosDodgePercent.Text);
            //Enemy 1
            persons[1] = new Person(enemys1Attack.Text,
                                     enemys1Life.Text,
                                     enemys1CriticalAttack.Text,
                                     enemys1AttackPercent.Text,
                                     enemys1CriticalAttackPercent.Text,
                                     enemys1DodgePercent.Text);

            //Enemy 2
            persons[2] = new Person(enemys2Attack.Text,
                                     enemys2Life.Text,
                                     enemys2CriticalAttack.Text,
                                     enemys2AttackPercent.Text,
                                     enemys2CriticalAttackPercent.Text,
                                     enemys2DodgePercent.Text);

            //Enemy 3
            persons[3] = new Person(enemys3Attack.Text,
                                     enemys3Life.Text,
                                     enemys3CriticalAttack.Text,
                                     enemys3AttackPercent.Text,
                                     enemys3CriticalAttackPercent.Text,
                                     enemys3DodgePercent.Text);

            //Enemy 4
            persons[4] = new Person(enemys4Attack.Text,
                                    enemys4Life.Text,
                                    enemys4CriticalAttack.Text,
                                    enemys4AttackPercent.Text,
                                    enemys4CriticalAttackPercent.Text,
                                    enemys4DodgePercent.Text);

            //Enemy 5
            persons[5] = new Person(enemys5Attack.Text,
                                    enemys5Life.Text,
                                    enemys5CriticalAttack.Text,
                                    enemys5AttackPercent.Text,
                                    enemys5CriticalAttackPercent.Text,
                                    enemys5DodgePercent.Text);

            Random r = new Random(unchecked((int)DateTime.Now.Ticks));

            int _countWin = 0;

            int[] _damage = new int[6];
            int[] _countFirstAttack = new int[6];
            int[] _countAllAttack = new int[6];
            int[] _countAttack = new int[6];
            int[] _countCriticalAttack = new int[6];
            int[] _countDodge = new int[6];

            int _idEnemy;
            int _life;
            bool isDodge = false;

            while (_countMatches != _startlimitMatches && persons[0].GetLife() > 0)
            {
                switch (r.Next(1, 3))
                {
                    // First was enemys attack
                    case 1:
                        for(int i = 1; i < 6; i++)
                        {
                            if(persons[i].GetLife() != 0)
                            {
                                _countFirstAttack[i]++;
                                break;
                            }
                        }
                        while (persons[0].GetLife() > 0 &&
                            persons[1].GetLife() > 0 ||
                               persons[2].GetLife() > 0 ||
                               persons[3].GetLife() > 0 ||
                               persons[4].GetLife() > 0 ||
                               persons[5].GetLife() > 0)
                        {

                            // Enemy 1
                            isDodge = false;
                            if (persons[1].GetLife() != 0)
                            {
                                _countAllAttack[1]++;
                                if (r.Next(1, 101) <= persons[1].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[1].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[1].GetCriticalAttack() + persons[1].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[1].GetCriticalAttack() - persons[1].GetAttack());
                                                _damage[1] = _damage[1] + persons[1].GetCriticalAttack() + persons[1].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[1] = _damage[1] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[1]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[1].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[1].GetAttack());
                                                _damage[1] = _damage[1] + persons[1].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[1] = _damage[1] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                        }
                                        _countAttack[1]++;
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 2
                            isDodge = false;
                            if (persons[2].GetLife() != 0)
                            {
                                _countAllAttack[2]++;
                                if (r.Next(1, 101) <= persons[2].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[2].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[2].GetCriticalAttack() + persons[2].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[2].GetCriticalAttack() - persons[2].GetAttack());
                                                _damage[2] = _damage[2] + persons[2].GetCriticalAttack() + persons[2].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[2] = _damage[2] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[2]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[2].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[2].GetAttack());
                                                _damage[2] = _damage[2] + persons[2].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[2] = _damage[2] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[2]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 3
                            isDodge = false;
                            if (persons[3].GetLife() != 0)
                            {
                                _countAllAttack[3]++;
                                if (r.Next(1, 101) <= persons[3].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[3].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[3].GetCriticalAttack() + persons[3].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[3].GetCriticalAttack() - persons[3].GetAttack());
                                                _damage[3] = _damage[3] + persons[3].GetCriticalAttack() + persons[3].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[3] = _damage[3] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[3]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[3].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[3].GetAttack());
                                                _damage[3] = _damage[3] + persons[3].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[3] = _damage[3] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[3]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 4
                            isDodge = false;
                            if (persons[4].GetLife() != 0)
                            {
                                _countAllAttack[4]++;
                                if (r.Next(1, 101) <= persons[4].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[4].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[4].GetCriticalAttack() + persons[4].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[4].GetCriticalAttack() - persons[4].GetAttack());
                                                _damage[4] = _damage[4] + persons[4].GetCriticalAttack() + persons[4].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[4] = _damage[4] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[4]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[4].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[4].GetAttack());
                                                _damage[4] = _damage[4] + persons[4].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[4] = _damage[4] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[4]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 5
                            isDodge = false;
                            if (persons[5].GetLife() != 0)
                            {
                                _countAllAttack[5]++;
                                if (r.Next(1, 101) <= persons[5].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[5].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[5].GetCriticalAttack() + persons[5].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[5].GetCriticalAttack() - persons[5].GetAttack());
                                                _damage[5] = _damage[5] + persons[5].GetCriticalAttack() + persons[5].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[5] = _damage[5] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[5]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[5].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[5].GetAttack());
                                                _damage[5] = _damage[5] + persons[5].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[5] = _damage[5] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[5]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Hero
                            do
                            {
                                _idEnemy = r.Next(1, 6);
                            } while (persons[_idEnemy].GetLife() == 0);

                            isDodge = false;
                            _countAllAttack[0]++;
                            if (r.Next(1, 101) <= persons[0].GetAttackPercent())
                            {
                                if (r.Next(1, 101) <= 100 - persons[_idEnemy].GetDodgePercent())
                                {
                                    if (persons[_idEnemy].GetLife() != 0)
                                    {
                                        if (r.Next(1, 101) <= persons[0].GetCriticalAttackPercent())
                                        {
                                            if (persons[_idEnemy].GetLife() >= persons[0].GetCriticalAttack() + persons[0].GetAttack())
                                            {
                                                persons[_idEnemy].SetLife(persons[_idEnemy].GetLife() - persons[0].GetCriticalAttack() - persons[0].GetAttack());
                                                _damage[0] = _damage[0] + persons[0].GetCriticalAttack() + persons[0].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[0] = _damage[0] + persons[_idEnemy].GetLife();
                                                persons[_idEnemy].SetLife(0);
                                            }
                                            _countCriticalAttack[0]++;
                                        }
                                        else
                                        {
                                            if (persons[_idEnemy].GetLife() >= persons[0].GetAttack())
                                            {
                                                persons[_idEnemy].SetLife(persons[_idEnemy].GetLife() - persons[0].GetAttack());
                                                _damage[0] = _damage[0] + persons[0].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[0] = _damage[0] + persons[_idEnemy].GetLife();
                                                persons[_idEnemy].SetLife(0);
                                            }
                                            _countAttack[0]++;
                                        }
                                        if (persons[_idEnemy].GetLife() <= 0)
                                        {
                                            _countWin++;
                                        }
                                    }
                                }
                                else
                                {
                                    isDodge = true;
                                    _countDodge[_idEnemy]++;
                                }
                            }
                            else
                            {
                                if (!isDodge)
                                {
                                    _countDodge[_idEnemy]++;
                                }
                            }


                        }

                        break;

                    // First was heros attack
                    case 2:
                        _countFirstAttack[0]++;
                        while (persons[0].GetLife() > 0 &&
                            persons[1].GetLife() > 0 ||
                               persons[2].GetLife() > 0 ||
                               persons[3].GetLife() > 0 ||
                               persons[4].GetLife() > 0 ||
                               persons[5].GetLife() > 0)
                        {
                            // Hero
                            do
                            {
                                _idEnemy = r.Next(1, 6);
                            } while (persons[_idEnemy].GetLife() == 0);

                            isDodge = false;
                            _countAllAttack[0]++;
                            if (r.Next(1, 101) <= persons[0].GetAttackPercent())
                            {
                                if (r.Next(1, 101) <= 100 - persons[_idEnemy].GetDodgePercent())
                                {
                                    if (persons[_idEnemy].GetLife() != 0)
                                    {
                                        if (r.Next(1, 101) <= persons[0].GetCriticalAttackPercent())
                                        {
                                            if (persons[_idEnemy].GetLife() >= persons[0].GetCriticalAttack() + persons[0].GetAttack())
                                            {
                                                persons[_idEnemy].SetLife(persons[_idEnemy].GetLife() - persons[0].GetCriticalAttack() - persons[0].GetAttack());
                                                _damage[0] = _damage[0] + persons[0].GetCriticalAttack() + persons[0].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[0] = _damage[0] + persons[_idEnemy].GetLife();
                                                persons[_idEnemy].SetLife(0);
                                            }
                                            _countCriticalAttack[0]++;
                                        }
                                        else
                                        {
                                            if (persons[_idEnemy].GetLife() >= persons[0].GetAttack())
                                            {
                                                persons[_idEnemy].SetLife(persons[_idEnemy].GetLife() - persons[0].GetAttack());
                                                _damage[0] = _damage[0] + persons[0].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[0] = _damage[0] + persons[_idEnemy].GetLife();
                                                persons[_idEnemy].SetLife(0);
                                            }
                                            _countAttack[0]++;
                                        }
                                        if (persons[_idEnemy].GetLife() <= 0)
                                        {
                                            _countWin++;
                                        }
                                    }
                                }
                                else
                                {
                                    isDodge = true;
                                    _countDodge[_idEnemy]++;
                                }
                            }
                            else
                            {
                                if (!isDodge)
                                {
                                    _countDodge[_idEnemy]++;
                                }
                            }

                            // Enemy 1
                            isDodge = false;
                            if (persons[1].GetLife() != 0)
                            {
                                _countAllAttack[1]++;
                                if (r.Next(1, 101) <= persons[1].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[1].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[1].GetCriticalAttack() + persons[1].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[1].GetCriticalAttack() - persons[1].GetAttack());
                                                _damage[1] = _damage[1] + persons[1].GetCriticalAttack() + persons[1].GetAttack();
                                            }
                                            else
                                            {
                                                //    _damage[1] = _damage[1] + persons[0].GetLife();
                                                //    persons[0].SetLife(0);
                                                break;
                                            }
                                            _countCriticalAttack[1]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[1].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[1].GetAttack());
                                                _damage[1] = _damage[1] + persons[1].GetAttack();
                                            }
                                            else
                                            {
                                                break;
                                                //    _damage[1] = _damage[1] + persons[0].GetLife();
                                                //    persons[0].SetLife(0);
                                            }
                                            _countAttack[1]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 2
                            isDodge = false;
                            if (persons[2].GetLife() != 0)
                            {
                                _countAllAttack[2]++;
                                if (r.Next(1, 101) <= persons[2].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[2].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[2].GetCriticalAttack() + persons[2].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[2].GetCriticalAttack() - persons[2].GetAttack());
                                                _damage[2] = _damage[2] + persons[2].GetCriticalAttack() + persons[2].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[2] = _damage[2] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[2]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[2].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[2].GetAttack());
                                                _damage[2] = _damage[2] + persons[2].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[2] = _damage[2] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[2]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 3
                            isDodge = false;
                            if (persons[3].GetLife() != 0)
                            {
                                _countAllAttack[3]++;
                                if (r.Next(1, 101) <= persons[3].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[3].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[3].GetCriticalAttack() + persons[3].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[3].GetCriticalAttack() - persons[3].GetAttack());
                                                _damage[3] = _damage[3] + persons[3].GetCriticalAttack() + persons[3].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[3] = _damage[3] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[3]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[3].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[3].GetAttack());
                                                _damage[3] = _damage[3] + persons[3].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[3] = _damage[3] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[3]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 4
                            isDodge = false;
                            if (persons[4].GetLife() != 0)
                            {
                                _countAllAttack[4]++;
                                if (r.Next(1, 101) <= persons[4].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[4].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[4].GetCriticalAttack() + persons[4].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[4].GetCriticalAttack() - persons[4].GetAttack());
                                                _damage[4] = _damage[4] + persons[4].GetCriticalAttack() + persons[4].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[4] = _damage[4] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[4]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[4].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[4].GetAttack());
                                                _damage[4] = _damage[4] + persons[4].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[4] = _damage[4] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[4]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                            // Enemy 5
                            isDodge = false;
                            if (persons[5].GetLife() != 0)
                            {
                                _countAllAttack[5]++;
                                if (r.Next(1, 101) <= persons[5].GetAttackPercent())
                                {
                                    if (r.Next(1, 101) <= 100 - persons[0].GetDodgePercent())
                                    {
                                        if (r.Next(1, 101) <= persons[5].GetCriticalAttackPercent())
                                        {
                                            if (persons[0].GetLife() >= persons[5].GetCriticalAttack() + persons[5].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[5].GetCriticalAttack() - persons[5].GetAttack());
                                                _damage[5] = _damage[5] + persons[5].GetCriticalAttack() + persons[5].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[5] = _damage[5] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countCriticalAttack[5]++;
                                        }
                                        else
                                        {
                                            if (persons[0].GetLife() >= persons[5].GetAttack())
                                            {
                                                persons[0].SetLife(persons[0].GetLife() - persons[5].GetAttack());
                                                _damage[5] = _damage[5] + persons[5].GetAttack();
                                            }
                                            else
                                            {
                                                _damage[5] = _damage[5] + persons[0].GetLife();
                                                persons[0].SetLife(0);
                                            }
                                            _countAttack[5]++;
                                        }
                                    }
                                    else
                                    {
                                        isDodge = true;
                                        _countDodge[0]++;
                                    }
                                }
                                else
                                {
                                    if (!isDodge)
                                    {
                                        _countDodge[0]++;
                                    }
                                }
                            }

                        }

                        break;
                }

                _startlimitMatches++;
                // Enemy 1
                int.TryParse(enemys1Life.Text, out _life);
                persons[1].SetLife(_life);
                // Enemy 2
                int.TryParse(enemys2Life.Text, out _life);
                persons[2].SetLife(_life);
                // Enemy 3
                int.TryParse(enemys3Life.Text, out _life);
                persons[3].SetLife(_life);
                // Enemy 4
                int.TryParse(enemys4Life.Text, out _life);
                persons[4].SetLife(_life);
                // Enemy 5
                int.TryParse(enemys5Life.Text, out _life);
                persons[5].SetLife(_life);
            }

            // Hero
            countHerosWin.Text = "Количество побед: " + _countWin.ToString();
            herosDamage.Text = "Внёс урона: " + _damage[0].ToString();
            countHeroesFirstAttack.Text = "Первым атакавал: " + _countFirstAttack[0].ToString();
            countAllHerosAttack.Text = "Общее количество атак: " + _countAllAttack[0];

            countHerosAttack.Text = "Количество атак: " + _countAttack[0].ToString();
            countHerosCriticalAttack.Text = "Количество критических атак: " + _countCriticalAttack[0].ToString();
            countHerosDodge.Text = "Количество уворотов: " + _countDodge[0].ToString();

            // Enemy 1
            enemys1Damage.Text = "Внёс урона: " + _damage[1].ToString();
            countEnemys1FirstAttack.Text = "Первым атакавал: " + _countFirstAttack[1].ToString();
            countAllEnemys1Attack.Text = "Общее количество атак: " + _countAllAttack[1];

            countEnemys1Attack.Text = "Количество атак: " + _countAttack[1].ToString();
            countEnemys1CriticalAttack.Text = "Количество критических атак: " + _countCriticalAttack[1].ToString();
            countEnemys1Dodge.Text = "Количество уворотов: " + _countDodge[1].ToString();

            // Enemy 2
            enemys2Damage.Text = "Внёс урона: " + _damage[2].ToString();
            countEnemys2FirstAttack.Text = "Первым атакавал: " + _countFirstAttack[2].ToString();
            countAllEnemys2Attack.Text = "Общее количество атак: " + _countAllAttack[2];

            countEnemys2Attack.Text = "Количество атак: " + _countAttack[2].ToString();
            countEnemys2CriticalAttack.Text = "Количество критических атак: " + _countCriticalAttack[2].ToString();
            countEnemys2Dodge.Text = "Количество уворотов: " + _countDodge[2].ToString();

            // Enemy 3
            enemys3Damage.Text = "Внёс урона: " + _damage[3].ToString();
            countEnemys3FirstAttack.Text = "Первым атакавал: " + _countFirstAttack[3].ToString();
            countAllEnemys3Attack.Text = "Общее количество атак: " + _countAllAttack[3];

            countEnemys3Attack.Text = "Количество атак: " + _countAttack[3].ToString();
            countEnemys3CriticalAttack.Text = "Количество критических атак: " + _countCriticalAttack[3].ToString();
            countEnemys3Dodge.Text = "Количество уворотов: " + _countDodge[3].ToString();

            // Enemy 4
            enemys4Damage.Text = "Внёс урона: " + _damage[4].ToString();
            countEnemys4FirstAttack.Text = "Первым атакавал: " + _countFirstAttack[4].ToString();
            countAllEnemys4Attack.Text = "Общее количество атак: " + _countAllAttack[4];

            countEnemys4Attack.Text = "Количество атак: " + _countAttack[4].ToString();
            countEnemys4CriticalAttack.Text = "Количество критических атак: " + _countCriticalAttack[4].ToString();
            countEnemys4Dodge.Text = "Количество уворотов: " + _countDodge[4].ToString();

            // Enemy 5
            enemys5Damage.Text = "Внёс урона: " + _damage[5].ToString();
            countEnemys5FirstAttack.Text = "Первым атакавал: " + _countFirstAttack[5].ToString();
            countAllEnemys5Attack.Text = "Общее количество атак: " + _countAllAttack[5];

            countEnemys5Attack.Text = "Количество атак: " + _countAttack[5].ToString();
            countEnemys5CriticalAttack.Text = "Количество критических атак: " + _countCriticalAttack[5].ToString();
            countEnemys5Dodge.Text = "Количество уворотов: " + _countDodge[5].ToString();

        }

        private void EnemysAttack()
        {

        }

        private void HerosAttack()
        {

        }

        private void invisibleText(TextBlock attackIsNotNumber, TextBlock attackLessZero,
                                   TextBlock lifeIsNotNumber, TextBlock lifeLessZero,
                                   TextBlock criticalAttackIsNotNumber, TextBlock criticalAttackLessZero,
                                   TextBlock attackPercentIsNotNumber, TextBlock attackPercentLessOne, TextBlock attackPercentMoreOneHundred,
                                   TextBlock criticalAttackPercentIsNotNumber, TextBlock criticalAttackPercentLessOne, TextBlock criticalAttackPercentMoreOneHundred,
                                   TextBlock dodgePercentIsNotNumber, TextBlock dodgePercentLessOne, TextBlock dodgePercentMoreOneHundred)
        {
            attackIsNotNumber.Visibility = Visibility.Hidden;
            attackLessZero.Visibility = Visibility.Hidden;

            lifeIsNotNumber.Visibility = Visibility.Hidden;
            lifeLessZero.Visibility = Visibility.Hidden;

            criticalAttackIsNotNumber.Visibility = Visibility.Hidden;
            criticalAttackLessZero.Visibility = Visibility.Hidden;

            attackPercentIsNotNumber.Visibility = Visibility.Hidden;
            attackPercentLessOne.Visibility = Visibility.Hidden;
            attackPercentMoreOneHundred.Visibility = Visibility.Hidden;

            criticalAttackPercentIsNotNumber.Visibility = Visibility.Hidden;
            criticalAttackPercentLessOne.Visibility = Visibility.Hidden;
            criticalAttackPercentMoreOneHundred.Visibility = Visibility.Hidden;

            dodgePercentIsNotNumber.Visibility = Visibility.Hidden;
            dodgePercentLessOne.Visibility = Visibility.Hidden;
            dodgePercentMoreOneHundred.Visibility = Visibility.Hidden;
        }

        private bool isNormallyWritten(TextBlock attackIsNotNumber, TextBlock attackLessZero,
                                       TextBlock lifeIsNotNumber, TextBlock lifeLessZero,
                                       TextBlock criticalAttackIsNotNumber, TextBlock criticalAttackLessZero,
                                       TextBlock attackPercentIsNotNumber, TextBlock attackPercentLessOne, TextBlock attackPercentMoreOneHundred,
                                       TextBlock criticalAttackPercentIsNotNumber, TextBlock criticalAttackPercentLessOne, TextBlock criticalAttackPercentMoreOneHundred,
                                       TextBlock dodgePercentIsNotNumber, TextBlock dodgePercentLessOne, TextBlock dodgePercentMoreOneHundred,
                                       TextBox attack, TextBox life, TextBox criticalAttack, TextBox attackPercent, TextBox criticalAttackPercent, TextBox dodgePercent)
        {
            int _attack;
            int _life;
            int _criticalAttack;
            int _attackPercent;
            int _criticalAttackPercent;
            int _dodgePercent;

            bool isAllOK = true;

            //Attack

            if (!int.TryParse(attack.Text, out _attack) && attack.Text != "")
            {
                attackIsNotNumber.Visibility = Visibility.Visible;
                isAllOK = false;
            }

            if (_attack < 0)
            {
                attackLessZero.Visibility = Visibility.Visible;
                isAllOK = false;
            }

            //Life
            if (!int.TryParse(life.Text, out _life) && life.Text != "")
            {
                lifeIsNotNumber.Visibility = Visibility.Visible;
                isAllOK = false;
            }

            if (_life < 0)
            {
                lifeLessZero.Visibility = Visibility.Visible;
                isAllOK = false;
            }

            //CriticalAttack
            if (!int.TryParse(criticalAttack.Text, out _criticalAttack) && criticalAttack.Text != "")
            {
                criticalAttackIsNotNumber.Visibility = Visibility.Visible;
                isAllOK = false;
            }

            if (_criticalAttack < 0)
            {
                criticalAttackLessZero.Visibility = Visibility.Visible;
                isAllOK = false;
            }

            //AttackPercent
            if (!int.TryParse(attackPercent.Text, out _attackPercent) && attackPercent.Text != "")
            {
                attackPercentIsNotNumber.Visibility = Visibility.Visible;
                isAllOK = false;
            }
            else
            {
                if(attackPercent.Text == "")
                {
                    _attackPercent = 1;
                }

                if (_attackPercent < 1)
                {
                    attackPercentLessOne.Visibility = Visibility.Visible;
                    isAllOK = false;
                }

                if (_attackPercent > 100)
                {
                    attackPercentMoreOneHundred.Visibility = Visibility.Visible;
                    isAllOK = false;
                }
            }

            //CriticalAttackPercent
            if (!int.TryParse(criticalAttackPercent.Text, out _criticalAttackPercent) && criticalAttackPercent.Text != "")
            {
                criticalAttackPercentIsNotNumber.Visibility = Visibility.Visible;
                isAllOK = false;
            }
            else
            {

                if (criticalAttackPercent.Text == "")
                {
                    _criticalAttackPercent = 1;
                }

                if (_criticalAttackPercent < 1)
                {
                    criticalAttackPercentLessOne.Visibility = Visibility.Visible;
                    isAllOK = false;
                }

                if (_criticalAttackPercent > 100)
                {
                    criticalAttackPercentMoreOneHundred.Visibility = Visibility.Visible;
                    isAllOK = false;
                }
            }

            //DodgePercent
            if (!int.TryParse(dodgePercent.Text, out _dodgePercent) && dodgePercent.Text != "")
            {
                dodgePercentIsNotNumber.Visibility = Visibility.Visible;
                isAllOK = false;
            }
            else
            {
                if (_dodgePercent < 0)
                {
                    dodgePercentLessOne.Visibility = Visibility.Visible;
                    isAllOK = false;
                }

                if (_criticalAttackPercent > 99)
                {
                    dodgePercentMoreOneHundred.Visibility = Visibility.Visible;
                    isAllOK = false;
                }
            }

            return isAllOK;
        }

        private bool Analysis()
        {
            bool isAllOK;

            //Hero
            invisibleText(herosAttackIsNotNumber, herosAttackLessZero,
                          herosLifeIsNotNumber, herosLifeLessZero,
                          herosCriticalAttackIsNotNumber, herosCriticalAttackLessZero,
                          herosAttackPercentIsNotNumber, herosAttackPercentLessOne, herosAttackPercentMoreOneHundred,
                          herosCriticalAttackPercentIsNotNumber, herosCriticalAttackPercentLessOne, herosCriticalAttackPercentMoreOneHundred,
                          herosDodgePercentIsNotNumber, herosDodgePercentLessZero, herosDodgePercentMoreNinetyNine);

            isAllOK = isNormallyWritten(herosAttackIsNotNumber, herosAttackLessZero,
                                      herosLifeIsNotNumber, herosLifeLessZero,
                                      herosCriticalAttackIsNotNumber, herosCriticalAttackLessZero,
                                      herosAttackPercentIsNotNumber, herosAttackPercentLessOne, herosAttackPercentMoreOneHundred,
                                      herosCriticalAttackPercentIsNotNumber, herosCriticalAttackPercentLessOne, herosCriticalAttackPercentMoreOneHundred,
                                      herosDodgePercentIsNotNumber, herosDodgePercentLessZero, herosDodgePercentMoreNinetyNine,
                                      herosAttack, herosLife, herosCriticalAttack, herosAttackPercent, herosCriticalAttackPercent, herosDodgePercent);

            //Enemy1
            invisibleText(enemys1AttackIsNotNumber, enemys1AttackLessZero,
                          enemys1LifeIsNotNumber, enemys1LifeLessZero,
                          enemys1CriticalAttackIsNotNumber, enemys1CriticalAttackLessZero,
                          enemys1AttackPercentIsNotNumber, enemys1AttackPercentLessOne, enemys1AttackPercentMoreOneHundred,
                          enemys1CriticalAttackPercentIsNotNumber, enemys1CriticalAttackPercentLessOne, enemys1CriticalAttackPercentMoreOneHundred,
                          enemys1DodgePercentIsNotNumber, enemys1DodgePercentLessZero, enemys1DodgePercentMoreNinetyNine);

            if (isAllOK)
            {
                isAllOK = isNormallyWritten(enemys1AttackIsNotNumber, enemys1AttackLessZero,
                                          enemys1LifeIsNotNumber, enemys1LifeLessZero,
                                          enemys1CriticalAttackIsNotNumber, enemys1CriticalAttackLessZero,
                                          enemys1AttackPercentIsNotNumber, enemys1AttackPercentLessOne, enemys1AttackPercentMoreOneHundred,
                                          enemys1CriticalAttackPercentIsNotNumber, enemys1CriticalAttackPercentLessOne, enemys1CriticalAttackPercentMoreOneHundred,
                                          enemys1DodgePercentIsNotNumber, enemys1DodgePercentLessZero, enemys1DodgePercentMoreNinetyNine,
                                          enemys1Attack, enemys1Life, enemys1CriticalAttack, enemys1AttackPercent, enemys1CriticalAttackPercent, enemys1DodgePercent);
            }

            //Enemy2
            invisibleText(enemys2AttackIsNotNumber, enemys2AttackLessZero,
                          enemys2LifeIsNotNumber, enemys2LifeLessZero,
                          enemys2CriticalAttackIsNotNumber, enemys2CriticalAttackLessZero,
                          enemys2AttackPercentIsNotNumber, enemys2AttackPercentLessOne, enemys2AttackPercentMoreOneHundred,
                          enemys2CriticalAttackPercentIsNotNumber, enemys2CriticalAttackPercentLessOne, enemys2CriticalAttackPercentMoreOneHundred,
                          enemys2DodgePercentIsNotNumber, enemys2DodgePercentLessZero, enemys2DodgePercentMoreNinetyNine);

            if (isAllOK)
            {
                isAllOK = isNormallyWritten(enemys2AttackIsNotNumber, enemys2AttackLessZero,
                                      enemys2LifeIsNotNumber, enemys2LifeLessZero,
                                      enemys2CriticalAttackIsNotNumber, enemys2CriticalAttackLessZero,
                                      enemys2AttackPercentIsNotNumber, enemys2AttackPercentLessOne, enemys2AttackPercentMoreOneHundred,
                                      enemys2CriticalAttackPercentIsNotNumber, enemys2CriticalAttackPercentLessOne, enemys2CriticalAttackPercentMoreOneHundred,
                                      enemys2DodgePercentIsNotNumber, enemys2DodgePercentLessZero, enemys2DodgePercentMoreNinetyNine,
                                      enemys2Attack, enemys2Life, enemys2CriticalAttack, enemys2AttackPercent, enemys2CriticalAttackPercent, enemys2DodgePercent);
            }

            //Enemy3
            invisibleText(enemys3AttackIsNotNumber, enemys3AttackLessZero,
                          enemys3LifeIsNotNumber, enemys3LifeLessZero,
                          enemys3CriticalAttackIsNotNumber, enemys3CriticalAttackLessZero,
                          enemys3AttackPercentIsNotNumber, enemys3AttackPercentLessOne, enemys3AttackPercentMoreOneHundred,
                          enemys3CriticalAttackPercentIsNotNumber, enemys3CriticalAttackPercentLessOne, enemys3CriticalAttackPercentMoreOneHundred,
                          enemys3DodgePercentIsNotNumber, enemys3DodgePercentLessZero, enemys3DodgePercentMoreNinetyNine);

            if (isAllOK)
            {
                isAllOK = isNormallyWritten(enemys3AttackIsNotNumber, enemys3AttackLessZero,
                                      enemys3LifeIsNotNumber, enemys3LifeLessZero,
                                      enemys3CriticalAttackIsNotNumber, enemys3CriticalAttackLessZero,
                                      enemys3AttackPercentIsNotNumber, enemys3AttackPercentLessOne, enemys3AttackPercentMoreOneHundred,
                                      enemys3CriticalAttackPercentIsNotNumber, enemys3CriticalAttackPercentLessOne, enemys3CriticalAttackPercentMoreOneHundred,
                                      enemys3DodgePercentIsNotNumber, enemys3DodgePercentLessZero, enemys3DodgePercentMoreNinetyNine,
                                      enemys3Attack, enemys3Life, enemys3CriticalAttack, enemys3AttackPercent, enemys3CriticalAttackPercent, enemys3DodgePercent);
            }

            //Enemy4
            invisibleText(enemys4AttackIsNotNumber, enemys4AttackLessZero,
                          enemys4LifeIsNotNumber, enemys4LifeLessZero,
                          enemys4CriticalAttackIsNotNumber, enemys4CriticalAttackLessZero,
                          enemys4AttackPercentIsNotNumber, enemys4AttackPercentLessOne, enemys4AttackPercentMoreOneHundred,
                          enemys4CriticalAttackPercentIsNotNumber, enemys4CriticalAttackPercentLessOne, enemys4CriticalAttackPercentMoreOneHundred,
                          enemys4DodgePercentIsNotNumber, enemys4DodgePercentLessZero, enemys4DodgePercentMoreNinetyNine);

            if (isAllOK)
            {
                isAllOK = isNormallyWritten(enemys4AttackIsNotNumber, enemys4AttackLessZero,
                                      enemys4LifeIsNotNumber, enemys4LifeLessZero,
                                      enemys4CriticalAttackIsNotNumber, enemys4CriticalAttackLessZero,
                                      enemys4AttackPercentIsNotNumber, enemys4AttackPercentLessOne, enemys4AttackPercentMoreOneHundred,
                                      enemys4CriticalAttackPercentIsNotNumber, enemys4CriticalAttackPercentLessOne, enemys4CriticalAttackPercentMoreOneHundred,
                                      enemys4DodgePercentIsNotNumber, enemys4DodgePercentLessZero, enemys4DodgePercentMoreNinetyNine,
                                      enemys4Attack, enemys4Life, enemys4CriticalAttack, enemys4AttackPercent, enemys4CriticalAttackPercent, enemys4DodgePercent);
            }

            //Enemy5
            invisibleText(enemys5AttackIsNotNumber, enemys5AttackLessZero,
                          enemys5LifeIsNotNumber, enemys5LifeLessZero,
                          enemys5CriticalAttackIsNotNumber, enemys5CriticalAttackLessZero,
                          enemys5AttackPercentIsNotNumber, enemys5AttackPercentLessOne, enemys5AttackPercentMoreOneHundred,
                          enemys5CriticalAttackPercentIsNotNumber, enemys5CriticalAttackPercentLessOne, enemys5CriticalAttackPercentMoreOneHundred,
                          enemys5DodgePercentIsNotNumber, enemys5DodgePercentLessZero, enemys5DodgePercentMoreNinetyNine);

            if (isAllOK)
            {
                isAllOK = isNormallyWritten(enemys5AttackIsNotNumber, enemys5AttackLessZero,
                                      enemys5LifeIsNotNumber, enemys5LifeLessZero,
                                      enemys5CriticalAttackIsNotNumber, enemys5CriticalAttackLessZero,
                                      enemys5AttackPercentIsNotNumber, enemys5AttackPercentLessOne, enemys5AttackPercentMoreOneHundred,
                                      enemys5CriticalAttackPercentIsNotNumber, enemys5CriticalAttackPercentLessOne, enemys5CriticalAttackPercentMoreOneHundred,
                                      enemys5DodgePercentIsNotNumber, enemys5DodgePercentLessZero, enemys5DodgePercentMoreNinetyNine,
                                      enemys5Attack, enemys5Life, enemys5CriticalAttack, enemys5AttackPercent, enemys5CriticalAttackPercent, enemys5DodgePercent);
            }

            return isAllOK;
        }
    }

    class Person
    {
        private int _attack;
        private int _life;
        private int _criticalAttack;
        private int _attackPercent;
        private int _criticalAttackPercent;
        private int _dodgePercent;

        public Person(String attack,
                  String life,
                  String criticalAttack,
                  String attackPercent,
                  String criticalAttackPercent,
                  String dodgePercent)
        {
            if(attack == "")
            {
                _attack = 0;
            }
            int.TryParse(attack, out _attack);

            if (life == "")
            {
                _life = 0;
            }
            int.TryParse(life, out _life);

            if (criticalAttack == "")
            {
                _criticalAttack = 0;
            }
            int.TryParse(criticalAttack, out _criticalAttack);

            if (attackPercent == "")
            {
                _attackPercent = 1;
            }
            int.TryParse(attackPercent, out _attackPercent);

            if (criticalAttackPercent == "")
            {
                _criticalAttackPercent = 1;
            }
            int.TryParse(criticalAttackPercent, out _criticalAttackPercent);

            if (dodgePercent == "")
            {
                _dodgePercent = 0;
            }
            int.TryParse(dodgePercent, out _dodgePercent);
        }

        //Attack
        public void SetAttack(int attack)
        {
            _attack = attack;
        }

        public int GetAttack()
        {
            return _attack;
        }

        //Life
        public void SetLife(int life)
        {
            _life = life;
        }

        public int GetLife()
        {
            return _life;
        }

        //CriticalAttack
        public void SetCriticalAttack(int criticalAttack)
        {
            _criticalAttack = criticalAttack;
        }

        public int GetCriticalAttack()
        {
            return _criticalAttack;
        }

        //AttackPercent
        public void SetAttackPercent(int attackPercent)
        {
            _attackPercent = attackPercent;
        }

        public int GetAttackPercent()
        {
            return _attackPercent;
        }

        //CriticalAttackPercent
        public void SetCriticalAttackPercent(int criticalAttackPercent)
        {
            _criticalAttackPercent = criticalAttackPercent;
        }

        public int GetCriticalAttackPercent()
        {
            return _criticalAttackPercent;
        }

        //DodgePercent
        public void SetDodgePercent(int dodgePercent)
        {
            _dodgePercent = dodgePercent;
        }

        public int GetDodgePercent()
        {
            return _dodgePercent;
        }
    }
}
