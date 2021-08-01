using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterItemPainter : InteractableObject
{
    public ColorType paintColor;

    public override void OnInteract(PlayerController pc)
    {
        if (!canInteract) { return; }

        if (!pc.HeldItem) { return; }

        base.OnInteract(pc);

        ColorType itemColor = pc.HeldItem.GetColor();

        if (paintColor == ColorType.White)
        {
            pc.HeldItem.SetColor(paintColor);
        }
        else
        {
            pc.HeldItem.SetColor(GetColorCombo(paintColor, itemColor));
        }
    }

    public ColorType GetColorCombo(ColorType a, ColorType b)
    {
        Debug.Log("Check color " + a.ToString() + " to " + b.ToString() );

        if (a == b)
        {
            return a;
        }

        if (a == ColorType.White)
        {
            return b;
        }

        if (b == ColorType.White)
        {
            return a;
        }

        if (CheckIfColorCombo(a,b, ColorType.Red, ColorType.Blue))
        {
            return ColorType.Purple;
        }

        if (CheckIfColorCombo(a, b, ColorType.Red, ColorType.Yellow))
        {
            return ColorType.Orange;
        }

        if (CheckIfColorCombo(a, b, ColorType.Blue, ColorType.Yellow))
        {
            return ColorType.Green;
        }

        return ColorType.Black;
    }

    bool CheckIfColorCombo(ColorType a, ColorType b, ColorType specColor1, ColorType specColor2)
    {
        if (a.Equals(specColor1) || a.Equals(specColor2))
        {
            if (b.Equals(specColor1) || b.Equals(specColor2))
            {
                if (a != b)
                {
                    return true;
                }
            }
        }

        return false;
    }

}


