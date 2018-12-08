import config from '@/packages/config'
import Vue from 'vue'

export default {
  getVotes () {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(data) })
    } else {
      return Vue.$http.get('api/vote').then((x) => {
        return x
      }).catch(error => {
        return error
      })
    }
  },
  addVote () {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve() })
    }
  }
}

const data = [
  {
    id: 1,
    gift: {
      id: 1,
      name: 'Телевизор LED LG 43UK6200',
      image: require('../assets/images/gifts/LED LG 43UK6200 2.jpg')
    },
    price: '29999 руб.',
    votesAgree: 111,
    votesDisagree: 2
  },
  {
    id: 2,
    gift: {
      id: 2,
      name: 'Микроволновая печь LG MH6336GIB',
      image: require('../assets/images/gifts/LG MH6336GIB.jpg')
    },
    price: '9999 руб.',
    votesAgree: 1,
    votesDisagree: 1
  },
  {
    id: 3,
    gift: {
      id: 3,
      name: 'Планшет Samsung GALAXY Tab S2 9.7',
      image: require('../assets/images/gifts/Samsung GALAXY Tab S2 32 ГБ 3G, LTE черный.jpg')
    },
    price: '29499 руб.',
    votesAgree: 23,
    votesDisagree: 0
  },
  {
    id: 4,
    gift: {
      id: 4,
      name: 'Стиральная машина Samsung WW60H2200EWD/LP',
      image: require('../assets/images/gifts/washmachine Samsung WW60H2200EWDLP.jpg')
    },
    price: '24499 руб.',
    votesAgree: 10,
    votesDisagree: 10
  },
  {
    id: 5,
    gift: {
      id: 5,
      name: 'Пылесос Thomas DryBOX AMFIBIA',
      image: require('../assets/images/gifts/Thomas DryBOX AMFIBIA.jpg')
    },
    price: '24999 руб.',
    votesAgree: 3,
    votesDisagree: 23
  },
  {
    id: 6,
    gift: {
      id: 6,
      name: 'Смартфон Samsung Galaxy A8+ SM-A730F',
      image: require('../assets/images/gifts/Samsung Galaxy A8+ SM-A730F 32 ГБ черный.jpg')
    },
    price: '22999 руб.',
    votesAgree: 66,
    votesDisagree: 12
  }
]
