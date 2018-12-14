import Vue from 'vue'
import Vuex from 'vuex'
import * as types from './mutation-types'
import auth from './auth'
import notify from './notify'
import gift from './gift'
import forum from './forum'
import busy from './busy'
import vote from './vote'
import info from './info'
import payment from './payment'

Vue.use(Vuex)

export const store = new Vuex.Store({
  plugins: [
    store => {
      store.subscribeAction((action, state) => {
        store.commit(types.CLEAR_ERRORS)
        store.commit(types.SET_LOADING, true)
      })
    }
  ],
  modules: {
    auth,
    notify,
    gift,
    forum,
    busy,
    vote,
    info,
    payment
    // category,
    // word,
    // busy
    // dialog,
    // training
  }
})
