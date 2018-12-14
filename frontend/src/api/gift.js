import Vue from 'vue'
import config from '@/packages/config'

export default {
  getGiftDraw: () => {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(giftDraw) })
    } else {
      return Vue.$http.get('api/giftdraw').then((x) => {
        return x
      }).catch(error => {
        return error
      })
    }
  },
  getGiftDrawByUser: (user) => {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(userGift) })
    } else {
    }
  }
}

const userGift = [
  { id: 1, userId: 1, giftId: 1, giftName: 'Телевизор', price: 30000, reached: 12300, giftImage: '/static/images/gifts/LED LG 43UK6200 2.jpg', giftIsActive: true, keys: [{ id: 1, key: 'key1' }, { id: 2, key: 'key2' }, { id: 3, key: 'key3' }] },
  { id: 2, userId: 1, giftId: 2, giftName: 'Холодильник', price: 27000, reached: 21000, giftImage: '/static/images/gifts/Samsung Galaxy A8+ SM-A730F 32 ГБ черный.jpg', giftIsActive: true, keys: [{ id: 4, key: 'key4' }, { id: 5, key: 'key5' }, { id: 6, key: 'key6' }] },
  { id: 3, userId: 1, giftId: 3, giftName: 'Телефон', price: 15999, reached: 5300, giftImage: '/static/images/gifts/Samsung Galaxy A8+ SM-A730F 32 ГБ черный.jpg', giftIsActive: false, keys: [{ id: 7, key: 'key7' }] }
]

const giftDraw = [
  { id: 1, giftName: 'Apple iPhone X', giftDescription: 'Смартфон Apple iPhone X – воплощение статуса, надежности и передовых технологий.', image: 'https://www.re-store.ru/upload/iblock/ea3/ea3a57da3137cf5be1c0b3d1e8999a37.jpg', imageLocal: '/static/images/example.jpg', info: 'test info 1', price: 77000.00, priceKey: 250.00, reached: 28250.00 },
  { id: 2, giftName: 'Samsung Galaxy Note 8', giftDescription: '6.3 Смартфон Samsung Galaxy Note 8 64 ГБ – устройство, в котором внимание уделялось всем деталям.', image: 'https://cdn.images.express.co.uk/img/dynamic/galleries/x701/260002.jpg', imageLocal: '/static/images/example.jpg', info: 'test info 2', price: 68000.00, priceKey: 250.00, reached: 0.00 },
  { id: 3, giftName: 'PlayStation 4 Pro', giftDescription: 'Игровая приставка PlayStation 4 Pro в полной мере оправдывает свое название. В приставке есть все необходимое для комфортного использования любимых игр. ', image: 'https://s0.rbk.ru/v6_top_pics/resized/1440xH/media/img/5/16/754733297837165.png', imageLocal: '/static/images/example.jpg', info: 'test info 3', price: 30000.00, priceKey: 150.00, reached: 0.00 },
  { id: 4, giftName: 'Microsoft Xbox One', giftDescription: 'Игровая приставка Microsoft Xbox One S + Forza Horizon 3 – лучшее, что вы можете приобрести, если являетесь заядлым поклонником видеоигр.', image: 'https://avatars.mds.yandex.net/get-mpic/195452/img_id1065977498717792190/9hq', imageLocal: '/static/images/example.jpg', info: 'test info 4', price: 25000.00, priceKey: 150.00, reached: 0.00 },
  { id: 5, giftName: 'Apple iPhone 7', giftDescription: 'Смартфон Apple iPhone 7 выполнен в герметичном черном алюминиевом корпусе, защищающем его от брызг, царапин и пыли. ', image: 'https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone7/apple-iphone-7-gallery-img-5.jpg', imageLocal: '/static/images/example.jpg', info: 'test info 5', price: 40000.00, priceKey: 200.00, reached: 0.00 }
]
