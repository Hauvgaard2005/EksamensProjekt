# EksamensProjekt
Der skal være en player som kæmper mod en sværm af enemies
Playeren skal skyde modstanderne og kunne samle xp op som de dropper
Ud fra det skal han kunne nå et vidst antal xp før han leveler op
Når han leveler op kan han opgradere mellem; Range, Damage og Speed på hans våben

## Actors

|ID|Actor|Description|
|---|---|---|
|0|Player|Spilleren som spiller spillet|
|1|Enemy|Modstanderen som targeter playeren
2|Projectile|Genstanden som skydes mod enemies

## MoSCoW
- Player MUST shoot projectiles at Enemy
- Enemy MUST be able to kill Player 
- Player MUST level up
- Projectiles MUST chance parameters based on levelup
- Projectiles MUST target the enemy
- The enemy MUST target the player 
- Players COULD change parameters on levelup
- Enemies COULD get stronger based on levelup