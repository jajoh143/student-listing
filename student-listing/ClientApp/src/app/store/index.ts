import * as fromAppReducer from "./app.reducer";
import { ActionReducerMap, MetaReducer } from "@ngrx/store";

export interface AppState {
  [fromAppReducer.APP_FEATURE_KEY]: fromAppReducer.IAppState;
}

export const reducers: ActionReducerMap<AppState> = {
  app: fromAppReducer.appReducer
};

export const metaReducers: MetaReducer<AppState>[] = [];
