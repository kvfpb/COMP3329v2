# COMP3329 Group Project

### &nbsp;&nbsp;Instruction :
1. Open the Scene at "Assets\Scenes\Movement"
2. If "Player Prefab" in Launcher is missing, put "Assets\Resources\User" in it

### &nbsp;&nbsp;Common potential bugs :
1. Should show in all players' view => only show to player who do it (try PunRPC)
3. Should only happen on Player A => happen on all Player (try photoView.IsMine)
4. Only Player A can do it when Player A fullfil the condition => Player B can do it when Player A fullfil the condition (try photoView.IsMine)

### &nbsp;&nbsp;To-do-list :
1. [End scene] blur camera after death 
2. [End scene] hide camera reticle ^
3. [End scene] show win/lose after blur ^
4. [End scene] show empty score board under win/lose ^
5. [End scene] press button to restart ^
6. [End scene] press button to Start scene ^ 
7. [ // ] Solve Player residual **Bug** ^
</br> - detoryAllPlayer before game restart
19. [Arena] build a simple island *
20. [ // ] Spawing Player on different location ^
21. [Supply] All possible Supply spawing in 3 rounds ^^
22. [Supply] Randomly spawing part of them ^
23. [Supply] Change amount of grenade in different supply ^
24. [Supply] Change different supply's color ^
25. [Supply] hide old supply ^
27. [Camera effect] Barrier camera effect     //yellow it  
28. [Camera effect] Barrier decay camera effect ^       //crack it (decay per second, wont break,  when hit get red screen)
29. [Camera effect] Dash camera effect          <-DONE
30. [Camera effect] Death camera effect         <-DONE
31. [Camera effect] Camera effect when get hitted       <-can be done soon
32. [Camera effect] Camera effect when under water      <-can be done soon (according to y-axis (lower than a value jau blue screen)) //take reference from games 深海迷航
17. [End scene] dead by what message ^
18. [ // ] Show choosen grenade ^^

### &nbsp;&nbsp;To-do-store :
1. [Arena] Complete the arena 
2. [Arena] make the edge more obvious
22. [ // ] Player random spawing system 
23. [BUG] Solve player-grenade no collision **Bug**
24. [End scene] Match result recording system
</br> - need : winner/loser name, dead reason, date, battle-duration
26. [End scene] Upadte End scene with match result recording system 
28. [sound] Start scene music 
29. [sound] End scene music 
31. [sound] supply spawing sound effect 
32. [sound] player death sound effect
31. [sound] background music
32. [sound] red,yellow grenade explosion sound effect
33. [sound] green grenade gas emition sound effect 
33. [sound] drop in water sound effect 
33. [sound] inside water sound effect 
33. [sound] ocean sound effect 
33. [sound] remote grenade setting sound effect 
35. [optional] two hit dead system
36. [optional] Add Grenade path 
37. [optional] change player skin 
38. [optional] Change sky box 
39. [optional] Change ground skin 
40. [optional] Change wall skin 
41. [optional] Change ocean skin 
42. [optional] Change oceanFloor skin  
43. [ // ] cant do anything before all player arrive 
43. [ // ] add wait player sence before all player arrive 
44. icon effect when button is pressed 
45. button no respond reason message 

### &nbsp;&nbsp;Temporary unsolvable bug :
1. Solve Explode effect retain **Bug**                <-solved 
</br> - destory function should put inside the effect
3. Solve Destroyed wall's scrap pass through ground **Bug** 
4. Solve Multiplayer delay(~0.25s) **Bug**
5. Solve Ground transparent when view from underground **Bug**
</br> - because it is a plane
6. Solve have error message when explode with barrier **Bug**
7. Some time player killed by enemy but player still alive in its own view
8. change caret color will also change text color
9. dahs to other player **Bug**
10. Too lag when with many Wooden chips
11. Round 3 Remote grenade icon **Bug** 

### &nbsp;&nbsp;What had been done :
1. [Cracker Grenade] Throw Grenade 
2. [Cracker Grenade] Grenade explosion
3. [Cracker Grenade] Solve pink Grenade **Bug**
4. [Movement] Camera movement
5. [Movement] Player movement
6. [Movement] Camera-Player Synchronization
7. [ // ] Solve sky box **Bug** 
8. [ // ] Combine Grenade and movement
9. [Cracker Grenade] Solve high speed Grenade ignore collision **Bug**
10. [Cracker Grenade] Grenade UI
11. [Cracker Grenade] Grenade UI count
12. [Supply] Pick Grenade
13. [Cracker Grenade] Solve player-grenade collision **Bug**
14. [Movement] Solve cant jump on box **Bug**
15. [Supply] Solve supply box cover **Bug** 
16. [Supply] Supply box interaction
17. [Supply] Disable Supply box movement
18. [Supply] Solve multi-Supply box **Bug**
19. [Supply] Spawn supply box
20. [Supply] Supply box spawning effect
21. [Arena] Create destoryable wall
22. [Cracker Grenade] Turn grenade to Red_Cracker Grenade
23. [Dash] Create dash function
24. [Dash] Solve dash fly **Bug**
25. [Dash] Solve dash penetrate **Bug**
26. [Dash] Solve dash fly box **Bug**
27. [Dash] Solve dash stick on the sky **Bug**
28. [Arena] Improve destroyed wall
29. [Dash] Dash coolown
30. [Dash] Dash UI
31. [Dash] Dash coolown count
32. [ // ] Spawn player
33. [Supply] Solve cant open supply **Bug**
34. [ // ] Turn into multiplayer
35. [Cracker Grenade] Solve multiplayer Grenades location non-synchronized **Bug** 
36. [Cracker Grenade] Solve multiplayer Grenades throw direction non-synchronized **Bug**
37. [Supply] Count number of player in the server 
38. [Supply] Synchronize supply box spawning time
39. [Supply] Synchronize supply box status
40. [ // ] UI for yellow and green grenade
41. [Barrier] UI for Barrier
42. [Cracker Grenade] Solve Granade explosion dont add froce to player **Bug**
43. [Cracker Grenade] Kill player by grenade
44. [End scene] Lock winner movemonet
45. [Barrier] Add Barrier
46. [Barrier] synchronize Barrier icon
47. [Barrier] block throw grenade when using barrier
48. [Barrier] Change grenade icon color when using barrier
49. [ // ] Close error box
50. [Barrier] Barrier Visual effect
51. [Barrier] Solve end game still can use Barrier **Bug**
52. [Barrier] Solve Barrier effect non-synchronized **Bug**
53. [Barrier] Solve win by attacking barrier **Bug** 
54. [Supply] Solve Supply re-open **Bug** 
55. [Supply] Solve Pick grenade through other player **Bug**
56. [Supply] Solve Supply re-pick **Bug**
57. [ // ] Solve run into different server **Bug** 
58. [Supply] Solve player2 cant open Supply **Bug** 
59. [Supply] Solve player1 open supply box through player2 **Bug**
60. [Supply] Optimalize supplyInteraction's script
61. [Supply] Solve Supply box2 animation **Bug**
62. [Start scene] a Camera filming the island 
63. [Start scene] Game title
64. [Start scene] Start scene Font Asset
64. [Start scene] Start scene Color Gradient
65. [Start scene] Create Start button 
66. [Start scene] Activate start button
67. [Start scene] Start button press effect
68. [Start scene] Remove camera reticle 
69. [Start scene] Player name entering space
70. [Start scene] Get player name
71. [Start scene] change caret color
72. [Start scene] remove placeholder when kick
73. [Start scene] Start only when name!=null
74. [Arena] Build water area 
75. [Arena] Die if fall into water area 
50. [Arena] keep the camera above the ocean
51. [Arena] fall slower under water 
51. [Arena] edit ocean wave
52. [ // ] change gas grenade icon position
53. [Cracker Grenade] choose Cracker Grenade by number key 
53. [Cracker Grenade] Solve mid-air explodion **Bug** 
54. [Remote grenade] choose Remote grenade by number key 
54. [Remote grenade] throw Remote grenade
55. [Remote grenade] Remote grenade pink **Bug**
56. [Remote grenade] Remote grenade mid-air **Bug** 
57. [Remote grenade] Remote grenade self-explodion **Bug**
45. [Remote grenade] Cant throw again **Bug**
34. [Remote grenade] activate Remote grenade
10. [Remote grenade] make explode time lock 
11. [Remote grenade] Synchronize Remote grenade count
11. [Remote grenade] Change remote grenade from detory to hide+tp
12. [Remote grenade] Remote grenade multiplayer **Bug**
13. [Remote grenade] Remote grenade hide non-Synchronized **Bug**
57. [Remote grenade] Remote grenade time icon
57. [Remote grenade] Remote grenade time icon v2
57. [Remote grenade] Remote grenade time icon function
42. [ // ] end game loop **Bug**
43. [Remote grenade] Remote grenade press 1 icon **Bug**
50. [Remote grenade] Test multiplayer Remote grenade icon function
56. [Remote grenade] refill Remote grenade 
23. [Remote grenade] create multi-Remote grenade 
23. [Remote grenade] Test multiplayer with multi-Remote grenade 
56. [Remote grenade] refill multi-Remote grenade 
56. [Remote grenade] Test multiplayer with refill multi-Remote grenade 
57. [Remote grenade] Remote grenade pass through ground **Bug**
58. [Remote grenade] Remote grenade cant kill **Bug**
59. [Remote grenade] Explode Remote grenade after death **Bug**
60. [Remote grenade] Explode Remote grenade after death error message **Bug**
61. [Remote grenade] Remote grenade press 1 icon **Bug**
62. [Remote grenade] Round 2 Remote grenade setup fail **Bug**
63. [Remote grenade] enlarge explodsion radius 
64. [Remote grenade] enlarge explodsion effect 
65. [Remote grenade] Remote grenade explodsion effect non-Synchronized **Bug**
66. [Remote grenade] lock x,z.posiiton after collision 
67. [Gas grenade] choose Gas grenade by number key
68. [Gas grenade] copy stuffs from Cracker Grenade for Gas grenade 
69. [Gas grenade] find gas effect 
70. [Gas grenade] close explodion effect for Gas grenade
71. [Gas grenade] create gas effect for Gas grenade
72. [Gas grenade] edit gas effect
73. [Gas grenade] gas loop explosion **Bug**
73. [Gas grenade] find gas effect v2 
73. [Gas grenade] edit gas effect v2 
73. [Gas grenade] put gas effects to the Gas grenade 
73. [Gas grenade] emit gas when gas grenade stop
73. [Gas grenade] gas effect extrem lag **Bug**
73. [Gas grenade] disable first gas effect
75. [Gas grenade] move too slow never stop **Bug** 
76. [Gas grenade] downward emit gas bug **Bug** 
77. [Gas grenade] change how first gas effect disappaer
78. [Gas grenade] change how second gas effect disappaer
14. [Gas grenade] add damage area 





