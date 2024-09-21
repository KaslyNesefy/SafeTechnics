using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuTablet : MonoBehaviour
{
    public Text textWatchTimer;
    public Text textCalendarWatch;
    public Text textWayEnum;
    public Text textWay1;
    public Text textWay2;
    public Text textWay3;
    public Text textWay4;
    public Text textWay5;
    public GameObject player;
    public GameObject panelPauseMenu;

    //Timer vars
    private DateTime timerDT;
    private DateTime timerZeroDT;
    private DateTime stopTimerDT;
    private int timerInt = 0;
    private int stopTimerInt = 0;

    public AudioSource notificationSound;
    //player modes
    //private int playerModeStartMenu = Player.playerModeStartMenu;
    //private int playerModeLevelsMenu = Player.playerModeLevelsMenu;
    //private int playerModeLevelWellDone = Player.playerModeLevelWellDone;
    //private int playerModeLevelOutOfTime = Player.playerModeLevelOutOfTime;
    //private int playerModeLevelInterrupted = Player.playerModeLevelInterrupted;
    private StateMenu_Start _stateMenu_Start;
    private StateMenu_Levels _stateMenu_Levels;
    private StateLevelEnd_WellDone _stateLevelEnd_WellDone;
    private StateLevelEnd_OutOfTime _stateLevelEnd_OutOfTime;
    private StateLevelEnd_InterruptedByPlayer _stateLevelEnd_InterruptedByPlayer;
    //level states
    private bool levelNotStarted = true;
    private bool levelAnywayEnded = false;

    private void Start()
    {
        panelPauseMenu.SetActive(false);
    }

    private void FixedUpdate()
    {
        //Levels starts only. DONT DO THERE ANYTHIN ELSE *******
        if (levelNotStarted)
        {
            switch (player.GetComponent<Player>().GetCurrentState())
            {
                case StateLevel_1: { Level1Spawn(); levelNotStarted = false; levelAnywayEnded = true; break; } //1 Level Start
                                                                                                               //case 2: { Level2Spawn(); levelNotStarted = false; levelAnywayEnded = true; break; } //2 Level Start
                                                                                                               //case 3: { Level3Spawn(); levelNotStarted = false; levelAnywayEnded = true; break; } //3 Level Start
                                                                                                               //case 4: { Level4Spawn(); levelNotStarted = false; levelAnywayEnded = true; break; } //4 Level Start
                                                                                                               //case 5: { Level5Spawn(); levelNotStarted = false; levelAnywayEnded = true; break; } //5 Level Start
            }
        }

        //Leave-Timer-LevelEnd Players mode switcher
        switch (player.GetComponent<Player>().GetCurrentState())
        {
            //LevelsMenu
            case StateMenu_Levels:
                {
                    textWayEnum.text = "Для выбора уровня нажмите\n" +
                                       "соответствующую цифру\n" +
                                       "на клавиатуре\n";
                    textWay1.text = "1 Завершение работы на пк\n";
                    textWay2.text = "2 Начало работы на пк\n";
                    textWay3.text = "3 Пожарная ситуация \n";
                    textWay4.text = " \n";
                    textWay5.text = " \n";
                    textWay1.enabled = true;
                    textWay2.enabled = true;
                    textWay3.enabled = true;
                    textWay4.enabled = true;
                    textWay5.enabled = true;

                    textWatchTimer.text = DateTime.UtcNow.AddHours(3).ToLongTimeString();
                    textCalendarWatch.text = DateTime.UtcNow.AddHours(3).ToShortDateString();
                    break;
                }
            //Levels
            case StateLevel_1:
                {
                    WorkableLevelTimer();
                    break;
                }
            //case 2: { WorkableLevelTimer(); break; }
            //case 3: { WorkableLevelTimer(); break; }
            //case 4: { if (player.GetComponent<Level4Logic>().phase < 3) { WorkableLevelTimer(); } break; }
            //case 5: { if (player.GetComponent<Level5Logic>().phase < 3) { WorkableLevelTimer(); } break; }
            //playerModeLevelInterrupted
            case StateLevelEnd_InterruptedByPlayer:
                {
                    if (levelAnywayEnded)
                    {
                        LevelInterrupted();
                        levelAnywayEnded = false;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                        player.GetComponent<Player>().SetNewState(_stateMenu_Levels);
                    break;
                }
            //playerModeOutOfTime
            case StateLevelEnd_OutOfTime:
                {
                    if (levelAnywayEnded)
                    {
                        RanOutOfTime();
                        levelAnywayEnded = false;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                        player.GetComponent<Player>().SetNewState(_stateMenu_Levels);
                    break;
                }
            //playerModeLevelDone
            case StateLevelEnd_WellDone:
                {
                    if (levelAnywayEnded)
                    {
                        WellDoneLevel();
                        levelAnywayEnded = false;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                        player.GetComponent<Player>().SetNewState(_stateMenu_Levels);
                    break;
                }
        }
    }

    private void RanOutOfTime()
    {
        //Scripts disables in timer
        levelNotStarted = true;
        textWayEnum.text = "Время вышло\n" +
                           "Нажмите E, чтобы вернуться\n" +
                           "в меню уровней";
        notificationSound.Play();
    }

    private void LevelInterrupted()
    {
        //Scripts disables itself
        levelNotStarted = true;
        textWayEnum.text = "Уровень прерван\n" +
                           "Нажмите E, чтобы вернуться\n" +
                           "в меню уровней";
        notificationSound.Play();
    }

    public void WellDoneLevel()
    {
        //To add Time to tablet Also we need instructions
        stopTimerInt = timerInt;
        stopTimerDT = timerZeroDT;
        stopTimerDT = stopTimerDT.AddSeconds(IntToSeconds(stopTimerInt));
        textWatchTimer.text = stopTimerDT.ToLongTimeString();

        //Scripts disables selfs in their code if errthin ok
        levelNotStarted = true;
        textWayEnum.text = "Уровень пройден успешно\n" +
                           "Нажмите E, чтобы вернуться\n" +
                           "в меню уровней";
        notificationSound.Play();
    }

    //Workable Timer F**k it
    private void WorkableLevelTimer()
    {
        if (timerInt > 0)
        {
            timerInt -= 2;
            timerDT = timerZeroDT;
            timerDT = timerDT.AddSeconds(IntToSeconds(timerInt));
            textWatchTimer.text = timerDT.ToLongTimeString();
            textCalendarWatch.text = DateTime.UtcNow.AddHours(3).ToShortDateString() + " " + DateTime.UtcNow.AddHours(3).ToLongTimeString();
        }
        //If ran out of time
        if (timerInt == 0)
        {
            //switch (player.GetComponent<Player>().GetCurrentState())
            //{
                //case StateLevel_1: { player.GetComponent<Level1Logic>().enabled = false; break; }
                //case 2: { player.GetComponent<Level2Logic>().enabled = false; break; }
                //case 3: { player.GetComponent<Level3Logic>().enabled = false; break; }
                //case 4: { player.GetComponent<Level4Logic>().enabled = false; break; }
                //case 5: { player.GetComponent<Level5Logic>().enabled = false; break; }
            //}
            player.GetComponent<Player>().SetNewState(_stateLevelEnd_OutOfTime);
        }

    }

    // Int-Sec converter
    private double IntToSeconds(int integer)
    {
        double seconds = 0;
        seconds = integer / 100;
        return seconds;
    }
    private int SecondsToInt(double seconds)
    {
        int y = 0;
        y = (int)seconds * 100;
        return y;
    }

    //Levels spawns only. DONT DO THERE ANYTHIN ELSE *******
    private void Level1Spawn()
    {
        //1 Level Compdeact
        notificationSound.Play();
        timerInt = SecondsToInt(60.0);
        textWayEnum.text = "Завершение работы:\n";
        textWay1.text = "1 Выключить принтер\n";
        textWay2.text = "2 Выключить компьютер\n";
        textWay3.text = "3 Поставить стул на место\n";
        textWay4.text = "4 Закрыть окна\n";
        textWay5.text = "5 Выключить свет";
        player.GetComponent<Level1Logic>().enabled = true;
    }

    private void Level2Spawn()
    {
        //2 Level
        notificationSound.Play();
        timerInt = SecondsToInt(60.0);
        textWayEnum.text = "Начало работы на ПК\n";
        textWay1.text = "1 Включить принтер\n";
        textWay2.text = "2 Включтиь компьютер\n";
        textWay3.text = "3 Поставить стул на место\n";
        textWay4.text = "4 Закрыть окна\n";
        textWay5.text = "5 Включить свет";
        player.GetComponent<Level2Logic>().enabled = true;
    }

    private void Level3Spawn()
    {
        //3 Level
        notificationSound.Play();
        timerInt = SecondsToInt(60.0);
        textWayEnum.text = "Пожарная ситуация\n";
        textWay1.text = "1 Включить сигнализацию\n";
        textWay2.text = "2 Обесточить кабинет\n";
        textWay3.text = "3 Закрыть окна\n";
        textWay4.text = "4 Потушить системный блок\n";
        textWay5.text = "5 Покинуть помещение";
        player.GetComponent<Level3Logic>().enabled = true;
    }

    private void Level4Spawn()
    {
        //4 Level
        notificationSound.Play();
        timerInt = SecondsToInt(30.0);
        textWayEnum.text = "Для прохождения необходимо\n" +
                           "1 Действие\n" +
                           "2 Действие\n" +
                           "3 Действие\n" +
                           "4 Действие\n" +
                           "5 Действие";
        player.GetComponent<Level4Logic>().enabled = true;
    }

    private void Level5Spawn()
    {
        //5 Level
        notificationSound.Play();
        timerInt = SecondsToInt(30.0);
        textWayEnum.text = "Для прохождения необходимо\n" +
                           "1 Действие\n" +
                           "2 Действие\n" +
                           "3 Действие\n" +
                           "4 Действие\n" +
                           "5 Действие";
        player.GetComponent<Level5Logic>().enabled = true;
    }
}
