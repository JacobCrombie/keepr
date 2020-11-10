<template>
  <div class="keep-component col-3 my-2">
    <div class="card">
      <img
        class="card-img-top"
        :src="keepProp.img"
        data-toggle="modal"
        data-target="#keep-modal"
        @click="viewPlus(keepProp)"
      />
      <div class="card-body">
        <h4 class="card-title">{{ keepProp.name }}</h4>
        <img class="rounded-circle" :src="keepProp.creator.picture" alt="" @click="profilePush"/>
      </div>
    </div>

    <div class="modal fade" id="keep-modal" tabindex="-1" role="dialog">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content card">
          <div class="modal-header">
            <h5 class="modal-title">{{ activeKeep.name }}</h5>
            <h5>{{ activeKeep.creator.name }}</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="card-body d-flex flex-row">
            <img class="card-img-left" :src="activeKeep.img" alt="" />
            <div class="modal-body">
              <h5>
                {{ activeKeep.description }}
              </h5>
              <img
                class="rounded-circle"
                :src="activeKeep.creator.picture"
                alt=""
                @click="profilePush"
                data-dismiss="modal"
              />
            </div>
          </div>
          <div class="modal-footer d-flex justify-content-between">
            <p>Views:{{ activeKeep.views }}</p>
            <p>Kept:{{ activeKeep.keeps }}</p>
            <button
              v-if="
                this.$route.name == 'Profile' &&
                this.profile.id == activeKeep.creatorId
              "
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
              @click="deleteKeep"
            >
              Delete Keep
            </button>
            <button
              v-if="this.$route.name == 'Vault' && profile.id == activeVault.creatorId"
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
              @click="deleteVaultKeep"
            >
              Remove Keep From Vault
            </button>
            <button type="button" class="btn btn-primary" @click="addKeep">
              Add To My Vault
            </button>
            <div class="form-group">
              <label for=""></label>
              <select class="form-control" v-model="vaultSelect">
                <option v-for="v in myVaults" :key="v.id" :value="v.id">
                  {{ v.name }}
                </option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import router from "../router/index.js";
export default {
  name: "keep-component",
  props: ["keepProp"],
  data() {
    return {
      vaultSelect: "",
    };
  },
  computed: {
    myVaults() {
      return this.$store.state.myVaults;
    },
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    profile() {
      return this.$store.state.profile;
    },
    activeVault(){
      return this.$store.state.activeVault
    }
  },
  methods: {
    viewPlus(keep) {
      this.$store.dispatch("setActiveKeep", keep);
      let count = this.activeKeep.views;
      count++;
      let keepEdit = {
        views: count,
        id: this.activeKeep.id,
        creatorId: this.activeKeep.creator.id,
        route: this.$route.name,
        vaultId: this.$route.params.id,
      };
      this.$store.dispatch("editKeepViews", keepEdit);
    },
    addKeep() {
      let addKeepData = {
        keepId: this.activeKeep.id,
        vaultId: this.vaultSelect,
      };
      this.$store.dispatch("addKeepToVault", addKeepData);
      let count = this.activeKeep.keeps;
      count++;
      let keepEdit = {
        keeps: count,
        id: this.activeKeep.id,
        creatorId: this.activeKeep.creator.id,
        route: this.$route.name,
        vaultId: this.$route.params.id,
      };
      this.$store.dispatch("editKeepKeeps", keepEdit);
      this.vaultSelect = "";
    },
    profilePush() {
      this.$store.dispatch("getProfileById", this.keepProp.creator.id);
    },
    deleteKeep() {
      if (this.$store.state.profile.id == this.activeKeep.creatorId) {
        this.$store.dispatch("deleteKeep", this.activeKeep);
      }
      return;
    },
    deleteVaultKeep() {
      let vaultKeep = {
        vaultId: this.$route.params.id,
        id: this.activeKeep.vaultKeepId,
      };
      this.$store.dispatch("deleteVaultKeep", vaultKeep);
    },
  },
  components: { router },
};
</script>


<style scoped>
.modal-dialog {
  max-width: 50vw;
}
</style>