import * as types from '../mutation-types'
import context from '@/api/gift'

const state = {
  giftDraw: []
}

// actions
const actions = {
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
  }
}

// getters
const getters = {
  getGiftsDraw: state => state.giftDraw
}

export default {
  state,
  getters,
  actions,
  mutations
}
