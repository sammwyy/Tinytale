const Resources = require("@core/resources");
const SoundSystem = require("@core/soundsystem");

const bgm = Resources.GetSound("tinytale:bgm_rude_buster");
SoundSystem.PlayBGM(bgm);
