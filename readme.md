# Line Bot Nuget Packages
## 介紹
專案為.Net Standard 2.0 程式庫，整理Line機器人的請求訊息模組化與訪問Line API，可以輕鬆的實作接收、推送訊息、取得用戶基本資訊等等。

## Getting started
專案包裝成Nuget套件[**david511382LineBot**](https://www.nuget.org/packages/david511382LineBot/)，可使用Nuget安裝。

## Model
### Message
[官方說明](https://developers.line.biz/en/docs/messaging-api/message-types/#image-messages)
#### TextMessage
[官方表情符號](https://developers.line.biz/media/messaging-api/emoji-list.pdf)
#### StickerMessage
[官方貼圖](https://developers.line.biz/media/messaging-api/sticker_list.pdf)
#### MediaMessage
圖片跟影片
連結必須是 HTTPS TLS 1.2 或更新
#### AudioMessage
音訊
連結必須是 HTTPS TLS 1.2 或更新
#### LocationMessage
所在位置
#### Imagemap message
尚未實作
[官方文檔](https://developers.line.biz/en/reference/messaging-api/#imagemap-message)
#### Template message
尚未實作
Buttons template
Confirm template
Carousel template
Image carousel template
#### Flex Message
尚未實作
### Quick reply
尚未實作