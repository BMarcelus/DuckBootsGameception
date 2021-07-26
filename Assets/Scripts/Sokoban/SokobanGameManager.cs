using UnityEngine;

public class SokobanGameManager : GameManager {
    public override void EnableGame(GameManager parentGame) {
        // Create a sokoban crate instead of setting the carried item of the player

        var item = MetaGameManager.instance.GetHeldItem();
        MetaGameManager.instance.ClearItem();

        base.EnableGame(parentGame);

        if (item != Item.ItemType.None) {
            // Create item

            var player = FindPlayer();
            var objects = SokobanController.instance.objects;

            int dx = 0;
            int dy = -1;
            if (player.y < objects.GetLength(1)/2) dy = 1;

            int x = player.x + dx;
            int y = player.y + dy;

            var obj = Instantiate(
                MetaGameManager.instance.GetItemVisualPrefab(item),
                player.transform.position + (player.moveTo - player.moveFrom) + new Vector3(dx, dy)*SokobanController.gridUnitSize,
                Quaternion.identity,
                activeObjects.transform);
            obj.transform.localPosition = new Vector3(
                    Mathf.Round(obj.transform.localPosition.x),
                    Mathf.Round(obj.transform.localPosition.y),
                    obj.transform.localPosition.z);

            var so = obj.AddComponent<SokobanObject>();
            so.x = x;
            so.y = y;
            objects[x, y] = so;
            so.type = SokobanObject.SokoType.Crate;
            so.itemType = item;
        }
    }

    public override void DisableGame() {
        // Take nearby item with us into the next game as the held item

        var player = FindPlayer();
        int x = player.x;
        int y = player.y;
        SokobanObject obj = null;
        Check(x+0, y+1, ref obj);
        Check(x+0, y-1, ref obj);
        Check(x+1, y+0, ref obj);
        Check(x-1, y+0, ref obj);
        Check(x+1, y+1, ref obj);
        Check(x-0, y+1, ref obj);
        Check(x+1, y-1, ref obj);
        Check(x-1, y-1, ref obj);
        if (obj != null) {
            MetaGameManager.instance.HoldItem(obj.itemType);
            SokobanController.instance.objects[obj.x, obj.y] = null;
            Destroy(obj.gameObject);
        }

        base.DisableGame();
    }

    void Check(int x, int y, ref SokobanObject obj) {
        if (obj != null) return;
        var objects = SokobanController.instance.objects;
        var b = objects[x, y];
        if (b != null && b.type == SokobanObject.SokoType.Crate && b.itemType != Item.ItemType.None) {
            obj = b;
        }
    }

    SokobanObject FindPlayer() {
        var objects = SokobanController.instance.objects;
        for (int x=0; x<objects.GetLength(0); x++) {
            for (int y=0; y<objects.GetLength(1); y++) {
                if (objects[x, y] != null && objects[x, y].type == SokobanObject.SokoType.Player) {
                    return objects[x, y];
                }
            }
        }
        return null;
    }
}
