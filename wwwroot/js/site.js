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
            let playersFound = data.Players.filter(player => {
                return player.displayName.indexOf(_userInput) >= 0;
            })
            let displayOfPlayers = document.querySelector('.playerInfo')
            displayOfPlayers.innerHTML = ''
            playersFound.slice(0, 3).forEach(function (playerData, index) {

                    displayOfPlayers.innerHTML += `
                      <div class="col-sm-4">
                        <dl class="dl-horizontal col-sm-10">
                            <dt>Player Name</dt>
                            <dd>${playerData.displayName}</dd>
                            <dt>Player Position</dt>
                            <dd>${playerData.position}</dd>
                            <dt>Player Team</dt>
                            <dd>${playerData.team}</dd>
                        </dl>
                        <button type="button" value="Create" class="btn btn-default col-sm-2 add-button" data-displayName="${playerData.displayName}">Add</button>
                      </div>
                    `;

            }, this);
            document.querySelectorAll(".add-button").forEach(button => {
                button.addEventListener("click", (e) => {
                    console.log(e.target);
                    const data = {
                        displayName : e.target.getAttribute("data-displayName")
                    }
                    // fetch -- post to the create player route
                    fetch("/PlayersInput/Create/", {
                        method: "POST",
                        headers: {
                            'Content-type': 'application/json'
                        },
                        body: JSON.stringify(data)
                    }).then(function(res){return res.json()})
                    .then((function(data){ alert(json.stringify(data))}))
                })
            })
        });
});

