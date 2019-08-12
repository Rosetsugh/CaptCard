# CaptCard

## Overview

CaptCard is a evaluation game, inspired by "Reigns".  Game asks player to choose one of two options. Chosen option then affects stats. Game's failure condition and success condition are not set on purpose. After 20 card, game asks player to continue or exit.

## Design

### Cards

Each card and its scenario are shown to player one by one. Cards have a face type to inform the player about what type of card they see. Also choices are contained in card objects so system can detect which choice to be written on Choice Interface. Choice have effectors for every stat. Effectors are simply numerical values either they are positive or negative.

### Interfaces

In game, there are three main interfaces :

- **Stats Interface**

  Stats Interface can contain different types. Stats are made of progress bars and their values are changed by option effectors.

- **Scenario Interface**

  Scenario Interface is simply a text field to be filled by displayed card scenario.

- **Choice Interface**

  *Choice Interface* is shown when player drags displayed card. Choice text is filled in which way the card is move towards to selectable ***choice***.

### Gameplay

Gameplay is based on touch input. Player needs to drag its finger on screen for choosing an *choice*. When player drags their finger to right direction, card moves to right relatively and for opposite side, same mechanics is applied. After choice selection is done, player will be expected to finish touch input then interfaces are informed, that is called **throwing a card**. Finally, new card is prepared to repeat gameplay process.

## Technical Details

The project is initialized with **Unity 2018.3**. 2D components are used. Google Sheets is used as database because it is easy to alter dataset, more natural to control and access. For Google Sheets connection there is an asset to produce data lists, it is called Google2Unity (G2U).

## Notes

Game is developed in 2018 as a request from a company called MargenTech. They are interested in new technologies about maritime. The game will be released in Google Play soon, if it hasn't happened yet, please contact with with via my email.
