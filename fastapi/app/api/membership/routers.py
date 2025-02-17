from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session

from app.database import get_db

from app.core.api import ApiPaginatedResponse
from app.core.pagination import PaginationRequest,paginate

from app.api.membership.schemas import ListMembershipsRequest, ListMembershipsResponse
from app.api.membership.repository import list_memberships_query

membership_router = APIRouter(
    prefix='/memberships',
    tags=['membership']
)

@membership_router.get(
    '/',
    response_model=ApiPaginatedResponse[ListMembershipsResponse],
)
async def list_memberships(
    db: Session = Depends(get_db),
    params: ListMembershipsRequest = Depends(),
    pagination: PaginationRequest = Depends()
):
    query = list_memberships_query(params=params)

    query, pagination_metadata = paginate(
        params=pagination,
        db=db,
        query=query,
    )

    return ApiPaginatedResponse(
        data=db.execute(query).all(),
        pagination=pagination_metadata,
    )
