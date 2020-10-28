import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";
import sa from "../services/SweetAlerts.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    activeKeep: {},
    vaults: [],
    myVaults: []
  },
  mutations: {

    //#region Profile
    setProfile(state, profile) {
      state.profile = profile;
    },
    //#endregion

    //#region Keeps
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    },

    //#endregion

    //#region Vaults
    setVaults(state, queryVaults) {
      state.vaults = queryVaults
    },
    setMyVaults(state, vaults) {
      state.myVaults = vaults
    }

    //#endregion

  },
  actions: {


    //#region Profile

    async getProfile({ commit, dispatch }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
        dispatch("getMyVaults", res.data.id)
      } catch (error) {
        console.error(error);
      }
    },

    //#endregion

    //#region Keeps
    async getAllKeeps({ commit, dispatch }) {
      let res = await api.get("keeps")
      commit("setKeeps", res.data)
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      await api.delete("keeps/" + keepId)
      dispatch("getAllKeeps")
    },
    async createKeep({ commit, dispatch }, keepData) {
      await api.post("keeps", keepData)
      dispatch("getKeepsByProfile", keepData.creatorId)
    },
    activeKeep({ commit, dispatch }, activeKeep) {
      commit("setActiveKeep", activeKeep)
    },
    async getKeepsByProfile({ commit, dispatch }, profId) {
      try {
        let res = await api.get("profiles/" + profId + "/keeps")
        commit("setKeeps", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getKeepsByVaultId({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId + "/keeps")
        commit("setKeeps", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async addKeepToVault({ commit, dispatch }, keepData) {
      try {
        await api.post("vaultkeeps", keepData)
      } catch (error) {
        console.error(error);
      }
    },
    async editKeep({ commit, dispatch }, keepEdit) {
      try {
        await api.put("keeps/" + keepEdit.id, keepEdit)
        if (keepEdit.creatorId == this.state.profile.id) {
          dispatch("getKeepsByProfile", keepEdit.creatorId)
        }
        dispatch("getAllKeeps")
      } catch (error) {
        console.error(error);
      }
    },

    //#endregion

    //#region Vaults
    async getVaultsByProfile({ commit, dispatch }, profId) {
      try {
        let res = await api.get("profiles/" + profId + "/vaults")
        commit("setVaults", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getMyVaults({ commit, dispatch }, profId) {
      try {
        let res = await api.get("profiles/" + profId + "/vaults")
        commit("setMyVaults", res.data)
      } catch (error) {
        console.error(error);
      }
    }

    //#endregion


  },
});
