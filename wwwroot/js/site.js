// Write your JavaScript code.
let playerSearch = document.querySelector('.searchPlayerName')
let playerForm = document.querySelector('form')
let input = document.querySelector('input')
let search = input.value
let url = "/proxy"

playerSearch.addEventListener('input', event => {
    const _userInput = event.target.value

    let playerInfo = fetch(url).then(response => response.json())
        .then(data => {
            console.log(data)
            console.log(data.Players[5].jersey)
            let playersFound = data.Players.filter(player => {
                return player.displayName.indexOf(_userInput) >= 0;
            })
            let displayOfPlayers = document.querySelector('.playerInfo')
            displayOfPlayers.innerHTML = ''
            playersFound.slice(0, 3).forEach(function (playerData, index) {

                    displayOfPlayers.innerHTML += `
                      <div class="row col-sm-4">
                        <dl class="dl-horizontal col-sm-1">
                            <dt>Player Name</dt>
                            <dd>${playerData.displayName}</dd>
                            <dt>Player Position</dt>
                            <dd>${playerData.position}</dd>
                            <dt>Player Team</dt>
                            <dd>${playerData.team}</dd>
                        </dl>
                        <button type="submit" value="Create" class="btn btn-default col-sm-1">Add</button>
                      </div>
                    `;
            }, this);
        });
});

