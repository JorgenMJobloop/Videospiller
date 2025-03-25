const countContent = document.getElementById("count-content");
const getContent = document.getElementById("get-content");


function openSidepanel() {
    document.getElementById("my-sidepanel").style.width = "150px";
    document.getElementById("open-sidepanel-btn").style.display = "none";
    getContent.style.display = "none";
    document.getElementById("media-content").style.display = "flex";
}

function closeSidepanel() {
    document.getElementById("my-sidepanel").style.width = "0";
    document.getElementById("my-sidepanel").style.transition = "1s";
    document.getElementById("open-sidepanel-btn").style.display = "block";
    getContent.style.display = "block";
    document.getElementById("media-content").style.display = "none";
    ifSidePanelClosed();
}




document.addEventListener("DOMContentLoaded", () => {
    const videoPlayer = document.getElementById("video-player");
    const videoTitleElement = document.getElementById("video-title");
    const videoDescriptionElement = document.getElementById("video-description");
    const videoFeedURLArray = ["./src/video/async.mp4", "./src/video/hashtable.mp4"];
    const videoMetadata = {
        title: ``,
        description: ``,
        thumbnail: "./src/thumbnails/Thumb1",
    };
    const videoThumbnails = document.createElement("img");

    async function fetchVideoFeed(url) {
        try {
            const response = await fetch(url);
            const videoBlob = await response.blob();
            const videoURL = URL.createObjectURL(videoBlob);

            videoPlayer.src = videoURL;
            videoPlayer.volume = 0.3;
            videoPlayer.play();

            /* Write some code that display more information about
               the video-metadata in markdown
            */

            videoTitleElement.textContent = videoMetadata.title;
            videoDescriptionElement.textContent = videoMetadata.description;
            videoThumbnails.src = `${videoMetadata.thumbnail}`

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
    const videoFeedURL = videoFeedURLArray[0];
    fetchVideoFeed(videoFeedURL);

})