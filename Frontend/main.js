const countContent = document.getElementById("count-content");
const getContent = document.getElementById("get-content");
const videoPlayer = document.getElementById("video-player");

function openSidepanel() {
    document.getElementById("my-sidepanel").style.width = "150px";
    document.getElementById("open-sidepanel-btn").style.display = "none";
    getContent.style.display = "none";
    document.getElementById("media-content").style.display = "flex";
    videoPlayer.style.display = "block";
}

function closeSidepanel() {
    document.getElementById("my-sidepanel").style.width = "0";
    document.getElementById("my-sidepanel").style.transition = "1s";
    document.getElementById("open-sidepanel-btn").style.display = "block";
    getContent.style.display = "block";
    document.getElementById("media-content").style.display = "none";
    videoPlayer.style.display = "none";
    ifSidePanelClosed();
}


/**
 * GET endpoint
 * @returns JSON object data from the RestAPI
 */
async function GetVideoData(url) {
    try {
        const response = await fetch(url);
        const data = await response.json();
        return data.map(value => {
            value.id,
                value.title,
                value.description,
                value.videoURL,
                value.numberOfLikes
        });
    }
    catch {
        console.error("There was an error fetching the data from the server!");
    }
}


document.addEventListener("DOMContentLoaded", () => {
    const videoDescriptionElement = document.getElementById("video-description");
    const videoMetadata = GetVideoData("http://localhost:5067/api/videos/");

    async function fetchVideoFeed(url) {
        try {
            const response = await fetch(url);
            const videoObject = await response.json();

            if (videoObject.length > 0) {
                console.log(videoObject);
                console.log("video url:", videoObject[0].videoURL);
                console.log("video description:", videoObject[0].description)

                videoPlayer.src = videoObject[0].videoURL;
                videoPlayer.volume = 0.3;
                await videoPlayer.play();

                videoDescriptionElement.textContent = videoObject[0].description;
            }
            /* 
                todo:
                    Write some code that display more information about
                    the video-metadata in markdown

                    use the backends GET method to fetch JSON video descriptions

            */

            window.ifSidePanelClosed = () => {
                videoPlayer.pause();
                closeSidepanel();
            }
        }
        catch (error) {
            console.error(`Error fetching video feed: ${error}`);
        }
    }
    // driver code with arguments!
    const videoFeedURL = "http://localhost:5067/api/videos";
    fetchVideoFeed(videoFeedURL);

})