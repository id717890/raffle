import config from '@/packages/config'

export default {
  getVotes () {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(data) })
    }
  }
}

const data = [
  {
    id: 1,
    gift: {
      id: 1,
      name: 'Стиральная машина'
    },
    votesAggree: 0,
    votesDisagree: 0
  },
  {
    id: 2,
    gift: {
      id: 2,
      name: 'Микроволновая печь'
    },
    votesAggree: 0,
    votesDisagree: 0
  },
  {
    id: 3,
    gift: {
      id: 3,
      name: 'Пылесос'
    },
    votesAggree: 0,
    votesDisagree: 0
  },
  {
    id: 4,
    gift: {
      id: 4,
      name: 'Телевизор'
    },
    votesAggree: 13,
    votesDisagree: 19
  }
]
