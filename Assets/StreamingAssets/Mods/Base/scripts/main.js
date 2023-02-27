const Camera = require("@core/camera");
const Player = require("@core/player");
const Resources = require("@core/resources");
const SoundSystem = require("@core/soundsystem");
const World = require("@core/world");

const bgm = Resources.GetSound("tinytale:bgm_rude_buster");
SoundSystem.PlayBGM(bgm);

const map = Resources.GetMap("tinytale:example");
World.LoadMap(map);

Player.Spawn(4, 4);
Camera.Follow(Player);
