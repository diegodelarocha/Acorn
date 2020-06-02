# Acorn - A Game Design Doll Rig

Meet Acorn 🐿! They're a humanoid character doll rig, that aims to aid fast game design prototyping, and better communication between game designers and animators in Unity 💛 💜

![](/Images/00_meetAcorn.png)


---------

## Getting Started

* Import Acorn (Instructions below).

* Drag and drop the prefab `/acorn/acorn.prefab` into your project's scene Hierarchy.

* Duplicate either `default [FK] -CopyStartPose-` or `default [IK] -CopyStartPose-` animation clip under `/acorn/animation tools/FK-IK default poses/` and rename it to whatever animation state name you will be prototyping *(ie: idle, walk, jump)*.

* Assign the animation clip to any `Animation Controller` of your preference, or drag and drop the clip into the `acorn` prefab on the hierarchy, if you don't have one yet, and this will create an `Animation Controller` with your just duplicated animation clip attached.

* Select the `acorn` prefab under your Hierarchy, and you should be able to see the duplicated animation clip assigned to the prefab and ready to be posed under the `Animation` window. *(You can find this window under `Window>Animation>Animation`)* 

* On the `Animation` tab, set your desired FPS under the `Samples` property *(ie: 24, 30, 60)*, enable `Keyframe recording mode` to automatically keyframe any edit you do on your pose, choose your desired frame to pose on and...

* ✨Start posing and have fun ✨! 

---------

## Installing

### Using Unity Package Manager ([Help](https://docs.unity3d.com/Manual/upm-git.html)) (Recommended):
1. Make sure you have [Git](https://git-scm.com/) installed on your computer.
2. Add Dependencies using Unity's Package Manager with the following git URLs: 
   
   * `https://github.com/madsbangh/EasyButtons.git#upm`
   * `https://github.com/sprylyltd/GLTFUtility.git`
  
3. Add Acorn on Package Manager with the following git URL:

  * `https://github.com/diegodelarocha/Acorn.git#release/upm`

![](/Images/PackageManager01.png)

4. From Acorn's Package Manager, Import into Project the necesesary assets:
   
  * `acorn + tools` = Includes Acorn's prefab, and animation tools.
  * `examples` = Includes example assets to give you an idea of what's possible. 

![](/Images/PackageManager02.png)

### Using Git or Zip download:

1. Make sure you have [Git](https://git-scm.com/) installed on your computer.

2. Dependencies are included on Acorn's Clone or Zip, but If you want to use Acorn in an existing project, add Dependencies on your Project using Unity's Package Manager with the following git URLs: 
   
   * `https://github.com/madsbangh/EasyButtons.git#upm`
   * `https://github.com/sprylyltd/GLTFUtility.git`
  
3. Clone or Download Zip:
   * Clone Acorn: `git clone git@github.com:diegodelarocha/Acorn.git`
   * Download [Acorn-master.zip](https://github.com/diegodelarocha/Acorn/archive/master.zip)
  
### Manual Git-less download:

1. Download [Acorn-embeded_dependencies.zip](https://github.com/diegodelarocha/Acorn/archive/release/embeded_dependencies.zip)

_This approach only works on it's own Project, and is not recommended if you want to be able to pull updates constantly, but it's helpful, for folks, that don't have access to Git, or just want to try/play with Acorn 💜._


### Version

To make sure Acorn works, use a Unity Version `2019.3.2f1` or higher, since this is the version it was created and tested on. It might work on older versions as long as you can install the dependencies, but it's untested.

---------

## Set Up Assets Folder

`/acorn/setup assets` - Includes raw assets used to build the `/acorn/acorn.prefab`, messing with any of these assets, might break your rig, so touch at your own risk ☠️🤓 

---------

## Examples and How To

Included you can find a Scene with some examples that showcases the rig's functionality under `/acorn/examples/acorn sample.unity`.
Click on the `acorn` prefab on the Hierarchy, and under the `Animation` tab, you can preview the different animation clips.

### FK - IK Switch

Acorn has both FK and IK functionality on limbs and head, and you can switch between these modes on all or a specific part of their body as you please.

![](/Images/01_IK-FKSwitch.png)

### FK - IK Switch - Inspector Menu

To access the FK-IK Switch menu, select `acorn`'s prefab on the Hierarchy, and you will find the component on the Inspector window.

This component has button switches, to switch all limbs and head at once, or separately, as well as a handy Visibility On/Off switch for all the character's handles.

![](/Images/02_IK-FKSwitchInspector.gif)

### FK - IK Switch - Set Animation Keyframes

To use the switch on animation clips, on the `Animator` window, scrub to the frame you'd like to use the switch on, then press the switch button you want to use on the `Inspector`, and press the `Add keyframe` button on the `Animator` to set a manual keyframe on Acorn. This will lock down the switch change on the selected frame.

*Make sure to set the keyframes manually, since `Keyframe recording mode` is not supported with these buttons*

![](/Images/03_IK-FKSwitchAnimKeyframe.gif)

### FK - IK Switch - IK Position & Rotation Match

Acorn's IK switch features IK position and rotation matching to the fk transforms on the switch for your convenience 🤓.

![](/Images/04_IK-FKMatch.gif)

### FK - IK Switch - Preview Animation Without Controllers

To preview animation without controller handles, simply enter `Play` mode 🤓, or use the `Visibility OFF` and `Visibility ON` buttons on `Edit` mode.

If for some reason you need to preview the handles again while on `Play` mode, the component script on Acorn's prefab, has a property at the bottom called `Handles Visibility`, toggle that `on` and `off` to your convenience.

![](/Images/05_visibilityToggle_playMore.png)

---------

### Body Parts Colour Swapping

Included under `/acorn/animation tools/animatable material colours/` you can find some coloured materials. While posing and the property `Keyframe recording mode` is enabled, you can drag and drop a specific colour to any body part of the rig, and it will get saved on the animation clip as a reference keyframe, this should be useful to have visual representations on when a designer wants to communicate an event should happen at a specific frame and area of the body. *(ie: At frame 5, hand goes red because particles of magic should come out of their hands at that moment)*.

![](/Images/06_colourSwapping.png)

---------

### Posing Example [Idle]

Example of an idle animation clip, to show how using Acorn, would work on a real world application to make an animation state.

![](Images/07_idle.png)

---------

### Interaction Objects

Included under `/acorn/animation tools/interaction objects/` you can find different coloured object primitives, that can be used as placeholder objects to help communicate things like particles, items, or any other object that would interact with Acorn over time, just drag and drop them as children of Acorn's prefab on the Hierarchy so that you can add their transforms as properties on the same animation clip that you're using for the rest of Acorn, once you add them just keyframe away.

Under the `idle` animation clip example, you can see this in use to accentuate and make clear on what frame we might want to see particles, or a trigger a sound when Acorn snaps their fingers 🤓.

![](/Images/08_interactionObjects_add.gif)
![](/Images/09_interactionObjects.gif)

---------

### Avatar and Avatar Masks

You can find an `Avatar` and an `Avatar Mask` under `/acorn/animation tools/avatars`, in case you want to combine and mask areas of two or more animation clips with the `Animator` layers.

On the following example, as `avatar mask greeting` animation clip is playing, `avatar mask hip hand` layer is toggled on and off to be able to add some right hand and hip sass to Acorn's pose. This layer is using an `Avatar Mask` to only let this layer use the right arm's and hip's transformation data, making it very handy to layer in extra needed movement to have an option of placing Acorn's right hand on their hips if we choose to 💜🧠.

![](/Images/10_avatarMasks.png)

---------

## Built With

* [EasyButtons](https://github.com/madsbangh/EasyButtons) - Easy buttons for the Unity default inspector by [Mads Bang Hoffensetz](https://twitter.com/madsbangh) - [LICENSE](https://github.com/madsbangh/EasyButtons/blob/master/LICENSE.txt)
* [FastIK](https://github.com/ditzel/SimpleIK) - Simple IK solver for Unity by [ditzel](https://github.com/ditzel) - [LICENSE](https://github.com/ditzel/SimpleIK/blob/master/LICENSE)
* [GLTFUtility](https://github.com/sprylyltd/GLTFUtility) - Wonderful modified GLTFUtility importer for Unity by [Bryant Drew Jones](https://bryantdrewjones.com/) - [LICENSE](https://github.com/sprylyltd/GLTFUtility/blob/master/LICENSE.md)
* [Newtonsoft's JSON library](https://www.newtonsoft.com/json)'s Unity Package - by [James Newton-King](https://github.com/JamesNK) - [LICENSE](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md)


---------

## Authors and Contributors

### Author

* [**Diego De la Rocha**](http://diegodelarocha.com) - *Character Doll creation, Workflow, Animation examples, and SetUp*

### Contributors

* [**Bryant Drew Jones**](https://bryantdrewjones.com/) - *GLTFUtility, and Game Design feedback*
* [**Daffodil**](https://daff.space/) - *Programming help*
* [**Em Halberstadt**](https://twitter.com/emaudible) - *Trailer Sound design 🎙*
* [**Jonathan Levstein**](http://www.jlevstein.com/) - *Programming help*
* [**Malcolm MacDonald**](http://malcolmmacdonald.ca/) - *MirrorPose functionality, Tool Inspiration, Programming help & Game Design feedback*

    _Also, check out Malcolm's Unity's Asset Store tool - [PoseableDoll](https://assetstore.unity.com/packages/tools/animation/poseable-doll-155286), which inspired a lot of what Acorn wanted to be, to become alive_ 😍💜🙏✨

* [**Yael Sagi**](https://www.behance.net/YaelSagi) - *Programming help*

---------

## License

This project is licensed under the MIT License - see the [LICENSE.md](/LICENSE.md) file for details

---------

## Third Party Notices

This project contains a third party notice which contains a list of the licenses of third party software used to build Acorn - see the  [Third Party Notices.md](/Third-Party-Notices.md) 
 file for details

---------

## Anti-Violence Request

In the hopes of a world with more positivity and care.

Acorn is a piece of software that would love to stay family friendly and violence free, hence, Acorn and their Author would really appreciate if you refrained from using Acorn to create any project or content that encourages, glorifies, incites, or calls for violence or phsycological and/or physical harm against an individual or a group of real or fictional characters; likewise, would appreciate that you do not use this piece of software to create any projects or content that glorifies or encourages the abuse of animals.

Understandably, there are sometimes reasons to create violent content _(e.g., educational, newsworthy, artistic, satire, documentary, etc.)_ so if you’re going to use it on something violent in nature that is similar to the previous examples on this paragraph, please ensure you provide context to the user so the reason for using it is clear and is done in the most sensible way possible to all users, to protect their physical and mental health as much as possible 💜.

In general, content where guns, murder, fighting, sexual violence, extreme violence, exploding characters, gore, warfare, and any other disturbing, and/or abusive content is involved, should be a no no please 🙏.

Mild violent content such as _(e.g., stepping over someone's garden by mistake, or making too much noise without the intent being to just be mean, or mild violence with sensible human character mistakes, like a character in a stressful situation where this might cause the character to overreact and become a bit rowdy.)_  should be okay.

I just plea that if you choose to include violence in your content or project, please think twice, if it's necessary/and or important for your project to exist. I trust and hope that you will use these guidelines at the best of your judgement to promote positivity over hate.✨ 

---------


## Contributing - Wish List Features

- [x] Create Package including dependencies [#1](https://github.com/diegodelarocha/Acorn/issues/1)
- [ ] Add Scaling capability to IK rig [#2](https://github.com/diegodelarocha/Acorn/issues/2)
- [ ] Add Stretchy Limbs [#3](https://github.com/diegodelarocha/Acorn/issues/3)
- [ ] Add Mirror Pose [#4](https://github.com/diegodelarocha/Acorn/issues/4)
