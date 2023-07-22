using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private bool mouseOver = false;
    private bool hasPPEBoots = true; // set back to false
    private bool completeRoom1PasswordPuzzle = false;

    public bool isSprayerUnlocked = false;
    private bool hasSprayer = false;
    private bool isLensUnlocked = false;

    private bool HoldingWetCore = false;
    public int Core2_Piece_Selected = 0;

    private bool hasSafetyGlasses = true; // set back to false

    private bool HasSieve = false;
    private bool isHoldingSieve = false;
    private bool hasPlacedSieve = false;

    private bool unlockedCabinetLock = false;

    private bool hasPuzzleBox;

    private bool PlacedAllPieces = false;
    private bool isJigSawDone = false;

    private bool hasDustMask = true; // set back to false

    private int currentRoom = 1;

    private bool fixedSawBlade = false;

    private bool unlockedFilingCabinetLock = false;

    private bool hasSawBlade = false;

    private bool isHoldingSawBlade = false;

    private bool isSawBladeFixed = false;

    private bool hasPlacedInspectCore = false;

    private bool isWaterOn = false;

    private bool isSawPowerOn = false;

    private bool holdingCutCore = true; //set back to false

    private bool foundGoldCore = true; //set back to false

    private bool isRoom3Unlocked = true; //set back to false

    private bool hasMagnetPen = false;
    private bool holdingMagnetPen = false;

    private bool isHoldingCorePiece = false;

    private bool hasUnlockedStorageRoom = false;

    private bool isHighContrastMode = false;
    private bool isScreenReader = false;

    private bool startGame = false;
    private bool endGame = false;

    private bool hasFoundSodaLiteRock = false;

    //Check Mouse Over State
    public bool GetMouseOver()
    {
        return mouseOver;
    }

    public void SetMouseOver(bool mo)
    {
        mouseOver = mo;
    }


    //Check if player has collected PPE Boots
    public bool GetPPEState()
    {
        return hasPPEBoots;
    }

    public void SetPPEState(bool ppe)
    {
        hasPPEBoots = ppe;
    }


    public bool GetRoom1PasswordPuzzle()
    {
        return completeRoom1PasswordPuzzle;
    }

    public void SetRoom1PasswordPuzzle(bool cp)
    {
        completeRoom1PasswordPuzzle = cp;

        Debug.Log("WORKED!!");
    }



    public bool GetIsSprayerUnlocked()
    {
        return isSprayerUnlocked;
    }

    public void SetIsSprayerUnlocked(bool sp)
    {
        isSprayerUnlocked = sp;


    }


    public bool GetSprayer()
    {
        return hasSprayer;
    }

    public void SetSprayer(bool sp)
    {
        hasSprayer = sp;


    }


    public bool GetIsLensUnlocked()
    {
        return isLensUnlocked;
    }

    public void SetIsLensUnlocked(bool sp)
    {
        isLensUnlocked = sp;
    }


    public bool GetIsHoldingWetCore()
    {
        return HoldingWetCore;
    }

    public void SetIsHoldingWetCore(bool wc)
    {
        HoldingWetCore = wc;
    }

    public int GetSelectedCore2()
    {
        return Core2_Piece_Selected;
    }

    public void SetSelectedCore2(int wc)
    {
        Core2_Piece_Selected = wc;
    }


    public bool GetHasSafetyGlasses()
    {
        return hasSafetyGlasses;
    }

    public void SetHasSafetyGlasses(bool sg)
    {
        hasSafetyGlasses = sg;
    }


    public bool GetHasSieve()
    {
        return HasSieve;
    }

    public void SetHasSieve(bool sv)
    {
        HasSieve = sv;
    }

    public bool GetIsHoldingSieve()
    {
        return isHoldingSieve;
    }

    public void SetIsHoldingSieve(bool hs)
    {
        isHoldingSieve = hs;
    }

    public bool GetHasPlacedSieve()
    {
        return hasPlacedSieve;
    }

    public void SetHasPlacedSieve(bool hs)
    {
        hasPlacedSieve = hs;
    }


    public bool GetHasUnlockedCabinetLock()
    {
        return unlockedCabinetLock;
    }

    public void SetHasUnlockedCabinetLock(bool cl)
    {
        unlockedCabinetLock = cl;
    }


    public bool GetHasPuzzleBox()
    {
        return hasPuzzleBox;
    }

    public void SetHasPuzzleBox(bool pb)
    {
        hasPuzzleBox = pb;
    }

    public bool GetPlacedAllPieces()
    {
        return PlacedAllPieces;
    }

    public void SetPlacedAllPieces(bool ap)
    {
        PlacedAllPieces = ap;
    }

    public bool GetJigSawDone()
    {
        return isJigSawDone;
    }

    public void SetJigSawDone(bool ap)
    {
        isJigSawDone = ap;
    }


    public bool GetHasDustMask()
    {
        return hasDustMask;
    }

    public void SetHasDustMask(bool dm)
    {
        hasDustMask = dm;
    }


    public int GetCurrentRoom()
    {
        return currentRoom;
    }

    public void SetCurrentRoom(int cr)
    {
        currentRoom = cr;
    }


    public bool GetFixedSawBlade()
    {
        return fixedSawBlade;
    }

    public void SetFixedSawBlade(bool fs)
    {
        fixedSawBlade = fs;
    }

    public bool GetHasUnlockedFilingCabinetLock()
    {
        return unlockedFilingCabinetLock;
    }

    public void SetHasUnlockedFilingCabinetLock(bool cl)
    {
        unlockedFilingCabinetLock = cl;
    }


    public bool GetHasSawBlade()
    {
        return hasSawBlade;
    }

    public void SetHasSawBlade(bool sb)
    {
        hasSawBlade = sb;
    }


    public bool GetisHoldingSawBlade()
    {
        return isHoldingSawBlade;
    }

    public void SetIsHoldingSawBlade(bool hs)
    {
        isHoldingSawBlade = hs;
    }

    public bool GetIsHoldingCorePiece()
    {
        return isHoldingCorePiece;
    }

    public void SetIsHoldingCorePiece(bool hs)
    {
        isHoldingCorePiece = hs;
    }

    public bool GetisSawBladeFixed()
    {
        return isSawBladeFixed;
    }

    public void SetisSawBladeFixed(bool hs)
    {
        isSawBladeFixed = hs;
    }

    public bool GetHasPlacedInspectCore()
    {
        return hasPlacedInspectCore;
    }

    public void SetHasPlacedInspectCore(bool pi)
    {
        hasPlacedInspectCore = pi;
    }


    public bool GetIsWaterOn()
    {
        return isWaterOn;
    }

    public void SetIsWaterOn(bool pi)
    {
        isWaterOn = pi;
    }

    public bool GetSawPower()
    {
        return isSawPowerOn;
    }

    public void SetSawPower(bool cc)
    {
        isSawPowerOn = cc;
    }

    public bool GetholdingCutCore()
    {
        return holdingCutCore;
    }

    public void SetholdingCutCore(bool cc)
    {
        holdingCutCore = cc;
    }


    public bool GetfoundGoldCore()
    {
        return foundGoldCore;
    }

    public void SetfoundGoldCore(bool cc)
    {
        foundGoldCore = cc;
    }

    public bool GetIsRoom3Unlocked()
    {
        return isRoom3Unlocked;
    }

    public void SetIsRoom3Unlocked(bool r3)
    {
        isRoom3Unlocked = r3;
    }

    public bool GetHasMagnetPen()
    {
        return hasMagnetPen;
    }

    public void SetHasMagnetPen(bool r3)
    {
        hasMagnetPen = r3;
    }

    public bool GetHoldingMagnetPen()
    {
        return holdingMagnetPen;
    }

    public void SetHoldingMagnetPen(bool r3)
    {
        holdingMagnetPen = r3;
    }

    public bool GetHasUnlockedStorageRoom()
    {
        return hasUnlockedStorageRoom;
    }

    public void SetHasUnlockedStorageRoom(bool r3)
    {
        hasUnlockedStorageRoom = r3;
    }

    public bool GetScreenReader()
    {
        return isScreenReader;
    }
    public void SetScreenReader(bool setting)
    {
        isScreenReader = setting;
    }
    public bool GetHighContrast()
    {
        return isHighContrastMode;
    }
    public void SetHighContrast(bool setting)
    {
        isHighContrastMode = setting;
    }

    public bool GetStartGame()
    {
        return startGame;
    }
    public void SetStartGame(bool sg)
    {
        startGame = sg;
    }

    public bool GetEndGame()
    {
        return endGame;
    }
    public void SetEndGame(bool eg)
    {
        endGame = eg;
    }


    public bool GetHasFoundSodaLite()
    {
        return hasFoundSodaLiteRock;
    }
    public void SetHasFoundSodaLite(bool eg)
    {
        hasFoundSodaLiteRock = eg;
    }
}

