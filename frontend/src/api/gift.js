import Vue from 'vue'
import config from '@/packages/config'

export default {
  getGiftDraw: () => {
    return Vue.$http.get('api/giftdraw').then((x) => {
      return x
    }).catch(error => {
      return error
    })
  },
  getGiftDrawByUser: (user) => {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(userGift) })
    } else {
    }
  }
}

const userGift = [
  {id: 1, userId: 1, giftId: 1, giftName: 'Телевизор', giftImage: null, giftIsActive: true, keys: [{id: 1, key: 'key1'}, {id: 2, key: 'key2'}, {id: 3, key: 'key3'}]},
  {id: 2, userId: 1, giftId: 2, giftName: 'Холодильник', giftImage: null, giftIsActive: true, keys: [{id: 4, key: 'key4'}, {id: 5, key: 'key5'}, {id: 6, key: 'key6'}]},
  {id: 3, userId: 1, giftId: 3, giftName: 'Телефон', giftImage: null, giftIsActive: false, keys: [{id: 7, key: 'key7'}]}
]
