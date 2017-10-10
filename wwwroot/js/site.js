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
            const nameList = document.createElement('dl')
            const defTitle = document.createElement('dt')
            const defContent = document.createElement('dd')
            displayOfPlayers.textContent = ''

            defContent.textContent += playerData.displayName

            displayOfPlayers.appendChild(nameSection)
            nameSection.setAttribute('class', 'playerInfo row')
            nameSection.appendChild(infoSection)
            infoSection.setAttribute('class', 'dl-horizontal col-sm-12')
            nameSection.appendChild(firstbreak)
            nameSection.appendChild(secondBreak)
            nameSection.appendChild(nameList)
            nameList.appendChild(defTitle)
            defTitle.appendChild(defContent)
            
        }, this);
    });  
});

