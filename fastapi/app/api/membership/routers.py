from fastapi import APIRouter, Depends, Session
from sqlalchemy.orm import Session

from app.database import get_db

from app.api.membership.schemas import GetMembershipsRequest

membership_router = APIRouter(
    prefix='/memberships',
    tags=['membership']
)

@membership_router.get('/')
def list_memberships(
    db: Session = Depends(get_db),
    params: GetMembershipsRequest = Depends(),
):
    return {}