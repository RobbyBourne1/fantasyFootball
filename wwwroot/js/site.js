// Write your JavaScript code.
let playerSearch = document.querySelector('.searchPlayerFn')
let playerForm = document.querySelector('form')
let input = document.querySelector('input')
let search = input.value
let url = "/proxy"
let displayOfPlayers = document.querySelector('.playerInfo')

playerSearch.addEventListener('input', event =>{
    const _userInput = event.target.value

    let playerInfo = fetch(url).then(response => response.json())
    .then(data => {
        console.log(data)
        console.log(data.Players[5].jersey)
        let playersFound = data.Players.filter(player =>{
            return player.displayName.indexOf(_userInput) >= 0;
        })
        console.log(playersFound)
        playersFound.forEach(function(playerData, index) {
            const nameSection = document.createElement('div')
            const infoSection = document.createElement('div')
            const firstbreak = document.createElement('br')
            const secondBreak = document.createElement('br')
            const thirdBreak = document.createElement('br')
            const fourthBreak = document.createElement('br')
            const nameList = document.createElement('dl')
            const defPN = document.createElement('dt')
            const defPP = document.createElement('dt')
            const defPT = document.createElement('dt')
            const PNContent = document.createElement('dd')
            const PPContent = document.createElement('dd')
            const PTContent = document.createElement('dd')
            displayOfPlayers.textContent = ''

            defPN.textContent = "Player Name"
            PNContent.textContent = playerData.displayName
            defPP.textContent = "Player Position"
            PPContent.textContent = playerData.position
            defPT.textContent = "Player Team"
            PTContent.textContent = playerData.team

            displayOfPlayers.appendChild(nameSection)
            nameSection.setAttribute('class', 'playerInfo row')
            nameSection.appendChild(infoSection)
            nameSection.appendChild(firstbreak)
            nameSection.appendChild(secondBreak)
            nameSection.appendChild(nameList)
            nameList.setAttribute('class', 'dl-horizontal col-sm-12')
            nameList.appendChild(defPN)
            nameList.appendChild(PNContent)
            nameList.appendChild(thirdBreak)
            nameList.appendChild(defPP)
            nameList.appendChild(PPContent)
            nameList.appendChild(fourthBreak)
            nameList.appendChild(defPT)
            nameList.appendChild(PTContent)
            
        }, this);
    });  
});

