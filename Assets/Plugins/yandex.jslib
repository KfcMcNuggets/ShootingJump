mergeInto(LibraryManager.library, {

  ShowFullscreen: function () {
      ysdk.adv.showFullscreenAdv({
      callbacks: {
          onOpen: function(wasShown) {
            console.log('������� Fullscreen ���������.');
          },
          onClose: function(wasShown) {
            console.log("������� Fullscreen ���������.");
            myGameInstance.SendMessage("YandexAds", "ContinueGame");
          },
          onError: function(error) {
            console.log("������ �� ������� Fullscreen.");
          }
      }
      })
  },

  ShowRewarded: function () {
      ysdk.adv.showRewardedVideo({
      callbacks: {
          onOpen: () => {
            console.log('������� Rewarded ���������.');
          },
          onRewarded: () => {
            console.log('������� Rewarded �����������, � ���������� ������� ������ �� ��������.');
            
          },
          onClose: () => {
            console.log('������� Rewarded ���������.');
          }, 
          onError: (e) => {
            console.log('������ �� ������� Rewarded:', e);
          }
      }
  })
  },

});