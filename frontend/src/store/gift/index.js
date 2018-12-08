import * as types from '../mutation-types'
import context from '@/api/gift'
import config from '@/packages/config'

const state = {
  giftDraw: [],
  giftDrawByUser: []
}

// actions
const actions = {
  async getGiftsDrawByUser ({commit, dispatch}) {
    return new Promise((resolve, reject) => {
      context.getGiftDrawByUser().then((x) => {
        if (config.isLocalApp()) {
          commit(types.RECIEVE_USER_GIFTS, x)
          commit(types.SET_LOADING, false)
          resolve()
        } else {
          if (x.status === 200) {
            commit(types.SET_GIFTS_DRAW, x.data)
            resolve()
          } else {
            dispatch('setErrors', x.response.data)
            reject(x.response.data)
          }
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  },
  async getGiftsDraw ({commit, dispatch}) {
    return new Promise((resolve, reject) => {
      context.getGiftDraw().then((x) => {
        if (x.status === 200) {
          commit(types.SET_GIFTS_DRAW, x.data)
          resolve()
        } else {
          dispatch('setErrors', x.response.data)
          reject(x.response.data)
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  }
}

// mutations
const mutations = {
  [types.SET_GIFTS_DRAW] (state, payload) {
    state.giftDraw = payload
  },
  [types.RECIEVE_USER_GIFTS] (state, payload) {
    state.giftDrawByUser = payload
  }
}

// getters
const getters = {
  getGiftsDraw: state => state.giftDraw,
  getGiftsDrawByUserActive: state => {
    if (state.giftDrawByUser.length > 0) {
      return state.giftDrawByUser.filter(x => x.giftIsActive === true)
    }
    return []
  },
  getGiftsDrawByUserNotActive: state => {
    if (state.giftDrawByUser.length > 0) {
      return state.giftDrawByUser.filter(x => x.giftIsActive === false)
    }
    return []
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
